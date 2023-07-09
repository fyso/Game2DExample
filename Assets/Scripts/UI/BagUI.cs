using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BagUI : MonoBehaviour
{
    public static BagUI instance;
    public HashSet<string> ItemIDs;
    public Dictionary<string, GameObject> activeItems;

    protected void Awake()
    {
        if(instance != null){
            Debug.LogWarning("Instance Has Exist!");
            Destroy(this);
        }

        instance = this;
        ItemIDs = new HashSet<string>();
        activeItems = new Dictionary<string, GameObject>();
        var childCount = transform.childCount;
        for(int i = 0; i < childCount; ++i)
        {
            var childT = transform.GetChild(i).gameObject;
            activeItems.Add(childT.name, childT);
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
        if(activeItems.ContainsKey(itemName))
        {
            activeItems[itemName].transform.SetAsLastSibling();
            activeItems[itemName].SetActive(true);
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
        activeItems[itemName].SetActive(false);
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
