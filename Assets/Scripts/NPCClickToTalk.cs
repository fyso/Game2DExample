using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using static UnityEditor.Progress;

public class NPCClickToTalk : MonoBehaviour
{
    private NPCConversation m_NPCConversation;
    TextAsset ItemListTXT;

    private void Start()
    {
        m_NPCConversation = GetComponent<NPCConversation>();
        ItemListTXT = Resources.Load<TextAsset>("ItemList");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(m_NPCConversation);
            string ItemList = ItemListTXT.text;
            string[] Items = ItemList.Split('\n');
            foreach (var item in Items)
            {
                ConversationManager.Instance.SetBool(item, true);
            }
        }
    }
}
