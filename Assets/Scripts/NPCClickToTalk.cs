using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using static UnityEditor.Progress;
using System.IO;

public class NPCClickToTalk : MonoBehaviour
{
    private NPCConversation m_NPCConversation;
    string ItemListTXT;

    private void Start()
    {
        m_NPCConversation = GetComponent<NPCConversation>();
        //ItemListTXT = Resources.Load<TextAsset>("ItemList");

        string outPath = Application.streamingAssetsPath;
        outPath += "/ItemInfo.txt";
        FileInfo fileInfo = new FileInfo(outPath);

        if (fileInfo.Exists)
        {
            ItemListTXT = File.ReadAllText(fileInfo.FullName);
        }
        else Debug.LogError($"No Item Save Exsit In {outPath}");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(m_NPCConversation);

            string[] Items = ItemListTXT.Split('\n');
            foreach (var item in Items)
            {
                ConversationManager.Instance.SetBool(item, true);
            }
        }
    }
}
