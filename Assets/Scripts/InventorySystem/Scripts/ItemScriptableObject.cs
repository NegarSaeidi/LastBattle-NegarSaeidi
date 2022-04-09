using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NewItem", menuName = "ItemSystem/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public new string name;
    public ItemType type;
    public GameObject slotPrefab;
    public Sprite itemIcon;
    public string description;

}
public enum ItemType
{
  ELIXIR_OF_LIFE,
  ELIXIR_OF_LIFE_BOOSTER,
  SILENT_SHIELD
}