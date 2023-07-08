using DialogueEditor;
using UnityEngine.UI;
using UnityEngine;

//��������˵����
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
