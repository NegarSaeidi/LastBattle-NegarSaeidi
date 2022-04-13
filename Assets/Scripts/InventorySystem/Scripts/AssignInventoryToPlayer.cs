using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AssignInventoryToPlayer : MonoBehaviour
{
    public InventoryScriptableObject inventory;




  
    public GameObject inventoryParent;
    public static Dictionary<ItemScriptableObject, GameObject> visibleItems = new Dictionary<ItemScriptableObject, GameObject>();

    private void Start()
    {
        if (visibleItems.Count > 0)
            visibleItems.Clear();
        if (inventory.listOfItems.Count > 0)
            inventory.listOfItems.Clear();
        CreateInventory();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pickup"))

        {

           
           
            var item = other.GetComponent<RepresentsItem>();
            if (item)
            {

                inventory.AddItem(item.item, 1, item.icon);
                if(item.item.name == "LIFE_ELIXIR_BOOSTER")
                {
                    other.GetComponent<AudioSource>().Play();
                    MovementController.boosterCount++;
                  
                }
                else if (item.item.name == "LIFE_ELIXIR")
                {
                    MovementController.elixirCount++;
                    other.GetComponent<AudioSource>().Play();
                }
                else
                {
                   
                    MovementController.shieldCount++;
                   
                }
                    UpdateInventory();
                other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y+500, other.transform.position.z);
                Destroy(other.gameObject,2.0f);
            }

        }

    }
    private void CreateInventory()
    {
        for (int i = 0; i < inventory.listOfItems.Count; i++)
        {
            var obj = Instantiate(inventory.listOfItems[i].item.slotPrefab, Vector3.zero, Quaternion.identity, inventoryParent.transform);
         
            obj.gameObject.name = inventory.listOfItems[i].item.name;
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.listOfItems[i].quantity.ToString("n0");
            obj.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = inventory.listOfItems[i].itemIcon;
            if (!visibleItems.ContainsKey(inventory.listOfItems[i].item))
                visibleItems.Add(inventory.listOfItems[i].item, obj);
        }
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < inventory.listOfItems.Count; i++)
        {
            if (inventory.listOfItems[i].quantity > 1)
            {

                visibleItems[inventory.listOfItems[i].item].GetComponentInChildren<TextMeshProUGUI>().text = inventory.listOfItems[i].quantity.ToString("n0");
            }
            else
            {
                if (!visibleItems.ContainsKey(inventory.listOfItems[i].item))

                {
                    var obj = Instantiate(inventory.listOfItems[i].item.slotPrefab, Vector3.zero, Quaternion.identity, inventoryParent.transform);

                    obj.gameObject.name = inventory.listOfItems[i].item.name;
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.listOfItems[i].quantity.ToString("n0");
                    obj.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = inventory.listOfItems[i].itemIcon;
                    obj.gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    visibleItems.Add(inventory.listOfItems[i].item, obj);
                }
            }
        }



    }
    private void OnApplicationQuit()
    {
        inventory.listOfItems.Clear();
    }
}