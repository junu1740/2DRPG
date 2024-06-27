using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public InventoryItemData[] items;
    public GameObject Purchase_UI;
    public Image ItemImage;
    public Text ItemName;
    public Text ItemCoin;
    public Text ItemExplain;

    private Dictionary<string, InventoryItemData> itemDictionary;

    private void Start()
    {
        itemDictionary = new Dictionary<string, InventoryItemData>();
        foreach (InventoryItemData item in items)
        {
            itemDictionary[item.itemID] = item;
        }
    }

    public void Selected(string itemID)
    {
        if(itemDictionary.TryGetValue(itemID, out InventoryItemData selectedItem)) 
        {
            Purchase_UI.SetActive(true);
            ItemImage.sprite = selectedItem.itemImage;
            ItemName.text = selectedItem.itemName;
            ItemCoin.text = $"({selectedItem.itemPrice:N0} Point)";
            ItemExplain.text = selectedItem.itemDescription;

        }
        else
        {
            Debug.LogError(" Not Found" +  itemID);
        }
    }


    
}
