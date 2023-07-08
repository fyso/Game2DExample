using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static BagItemInfos;

public class BagUI : Singleton<BagUI>
{
    public BagItemInfos BagInfo;
    public HashSet<string> ItemIDs;
    public List<BagItemInfo> BagItems;
    public Dictionary<string, GameObject> activeItems;

    override protected void Awake()
    {
        base.Awake();
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

    public void PrintItemTextOut()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach(var item in ItemIDs)
        {
            stringBuilder.Append(item.ToString());
            stringBuilder.Append('\n');
        }
        string outPath = Application.streamingAssetsPath;
        if (!Directory.Exists(outPath))
        {
            Directory.CreateDirectory(outPath);
        }
        Debug.Log($"BagItemInfo Out: {outPath} {File.Exists(outPath)}");


        outPath += "/ItemInfo.txt";
        Debug.Log($"BagItemInfo Out: {outPath}");
        FileInfo fileInfo = new FileInfo(outPath);

        if(!fileInfo.Exists)
        {
            var sw = fileInfo.CreateText();
            sw.Close();
        }
        File.WriteAllText(outPath,stringBuilder.ToString());

    }
}
