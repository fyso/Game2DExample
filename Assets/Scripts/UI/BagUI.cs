using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static BagItemInfos;

public class BagUI : MonoBehaviour
{
    public BagItemInfos BagInfo;
    public HashSet<string> ItemIDs;
    public List<BagItemInfo> BagItems;
    public Dictionary<string, GameObject> activeItems;
    private void Awake()
    {
        ItemIDs = new HashSet<string>();
        BagItems = new List<BagItemInfo>();
        activeItems = new Dictionary<string, GameObject>();
    }
    public void ShowItem(string itemName)
    {
        if (ItemIDs.Contains(itemName))
        {
            Debug.LogWarning("Item Has Exist!");
            return;
        }
        ItemIDs.Add(itemName);
        foreach (var item in BagInfo.ItemInfos)
        {
            if (item.Name == itemName)
            {
                var obj = Instantiate(item.ItemPrefab,transform);
                obj.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
                activeItems.Add(item.Name, obj);
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
        Destroy(activeItems[itemName]);
        activeItems.Remove(itemName);
    }

    public bool HasExist(string itemName)
    {
        return ItemIDs.Contains(itemName);
    }
}
