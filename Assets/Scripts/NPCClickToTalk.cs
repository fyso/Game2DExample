using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using System.IO;

public class NPCClickToTalk : MonoBehaviour
{
    public string NPCName;
    private NPCConversation m_NPCConversation;
    string ItemListTXT;

    private void Awake()
    {
        ConversationManager.OnConversationStarted += readItems;
        ConversationManager.OnConversationEnded += EndTalkWithNPC;
    }

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

    private void OnDestroy()
    {
        ConversationManager.OnConversationStarted -= readItems;
        ConversationManager.OnConversationEnded -= EndTalkWithNPC;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClicableManager.Instance.TalkOneNPC(NPCName);

            ConversationManager.Instance.StartConversation(m_NPCConversation);
            
        }
    }

    public void readItems()
    {
        string[] Items = ItemListTXT.Replace("\r"," ").Replace("\n", " ").Split(' ');
        foreach (var item in Items)
        {
            ConversationManager.Instance.SetBool(item, true);
        }
    }
    public void EndTalkWithNPC()
    {
        ClicableManager.Instance.EndTalkWithNPC();
    }
}
