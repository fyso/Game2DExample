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
    virtual public void PlayConversation()
    {
        TryPlayConversation();
    }
    virtual public bool TryPlayConversation()
    {

        if (GameManager.Instance.TryClick())
        {
            var selfConversation = GetComponent<NPCConversation>();
            ConversationManager.Instance.StartConversation(selfConversation);
            return true;
        }
        else
        {
            GameManager.Instance.ClickNumRunOut();
            return false;
        }
    }

}
