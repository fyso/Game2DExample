using System.Collections.Generic;
using UnityEngine;

public class BagUI : MonoBehaviour
{
    public HashSet<string> ItemIDs;
    public List<GameObject> BagItems;
    private void Awake()
    {
        ItemIDs = new HashSet<string>();
        BagItems = new List<GameObject>();

        var count = transform.childCount;
        for(int i = 0; i < count; i++)
        {
            var child = transform.GetChild(i).gameObject;
            if(child != null) BagItems.Add(child);
        }
    }
    public void ShowItem(string itemName)
    {
        if (ItemIDs.Contains(itemName))
        {
            Debug.LogWarning("Item Has Exist!");
            return;
        }
        ItemIDs.Add(itemName);
        foreach (var item in BagItems)
        {
            if (item.name == itemName)
            {
                item.gameObject.SetActive(true);
            }
        }
    }
    public void DisableItem(string itemName)
    {
        if (!ItemIDs.Contains(itemName))
        {
            Debug.LogWarning("Item Don't Exist!");
            return;
        }
        ItemIDs.Remove(itemName);

        foreach (var item in BagItems)
        {
            if (item.name == itemName)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    public bool HasExist(string itemName)
    {
        return ItemIDs.Contains(itemName);
    }
}
