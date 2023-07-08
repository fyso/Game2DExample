using DialogueEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CoversationButton : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PlayConversation);
    }
    public void PlayConversation()
    {
        var selfConversation = GetComponent<NPCConversation>();
        ConversationManager.Instance.StartConversation(selfConversation);
    }
}
