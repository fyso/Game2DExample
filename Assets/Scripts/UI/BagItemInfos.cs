
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemInfos", menuName ="GJ/ItemInfos", order = 0)]
public class BagItemInfos : ScriptableObject
{
    [System.Serializable]
    public class BagItemInfo
    {
        public string Name;
        public GameObject ItemPrefab;
    }
    public List<BagItemInfo> ItemInfos = new List<BagItemInfo>();
}
