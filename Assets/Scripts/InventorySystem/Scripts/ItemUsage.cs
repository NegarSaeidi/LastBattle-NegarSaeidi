
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script manages the usage of items. Whenever user clicks on an item slot,
/// if the quantity of the item is equal to 1
/// the item gets removed from the item list
/// and the item slot gets disappeared.
/// but if the quantity is more than one, we just simply subtract the quantity by 1
/// </summary>
public class ItemUsage : MonoBehaviour
{
    public InventoryScriptableObject inventory;
    //[Header("Audio")]
    //public AudioClip[] equipClip;

   

    //public GameObject closeButton;


    public void OnItemClicked()
    {
        //if (closeButton == null)
        //{
        //    GameObject[] button = GameObject.FindGameObjectsWithTag("CloseButton");
        //    closeButton = button[0];
        //}

        //closeButton.GetComponent<Button>().interactable = false;
        //StartCoroutine(delayForRepositioning());

    
        if (int.Parse(gameObject.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text) > 1)
        {

            int count = int.Parse(gameObject.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text);
            gameObject.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = (count - 1).ToString();
            for (int i = 0; i < inventory.listOfItems.Count; i++)
            {
                if (inventory.listOfItems[i].item.name == gameObject.name)
                {
                
                    // Item usage >> Implement potions

                    Debug.Log("Item destroyed type: " + inventory.listOfItems[i].item.type);
                 

                    inventory.listOfItems[i].SubtractQuantity(inventory.listOfItems[i].quantity);
                }
            }
        }
        else
        {
            for (int i = 0; i < inventory.listOfItems.Count; i++)
            {
                if (inventory.listOfItems[i].item.name == gameObject.name)
                {
                   

                    AssignInventoryToPlayer.visibleItems.Remove(inventory.listOfItems[i].item);

                    // Item usage >> Potions and Spell books
                    Debug.Log("Item destroyed type: " + inventory.listOfItems[i].item.type);
                  

                    inventory.RemoveItem(inventory.listOfItems[i].item, 1);
                    Destroy(gameObject);
                }
            }
            //if ((GetComponent<AudioSource>().isPlaying))
            //{

            //    GetComponent<Image>().color = new Color(0, 0, 0, 0);
            //    transform.GetChild(0).gameObject.SetActive(false);
            //    transform.GetChild(1).gameObject.SetActive(false);
            //    StartCoroutine(delayBeforeDestroy());

            //}
        }

      
      
    }
    IEnumerator delayBeforeDestroy()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
    IEnumerator delayForRepositioning()
    {
        yield return new WaitForSeconds(0.8f);
        //closeButton.GetComponent<Button>().interactable = true;
    }
}