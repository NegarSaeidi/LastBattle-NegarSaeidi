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

            //------VINEET's note: this is item score on item pickup
           
            var item = other.GetComponent<RepresentsItem>();
            if (item)
            {

                inventory.AddItem(item.item, 1, item.icon);
                UpdateInventory();
                Destroy(other.gameObject);
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