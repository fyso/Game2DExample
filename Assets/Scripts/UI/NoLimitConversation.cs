using DialogueEditor;
using UnityEngine.UI;
using UnityEngine;

//给背包的说明用
[RequireComponent(typeof(Button))]
public class NoLimitConversation : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PlayConversation);
    }
    virtual public void PlayConversation()
    {
        var selfConversation = GetComponent<NPCConversation>();
        if(selfConversation != null)
            ConversationManager.Instance.StartConversation(selfConversation);
    }

}
