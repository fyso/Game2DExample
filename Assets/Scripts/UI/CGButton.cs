using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(NPCConversation))]
public class CGButton : MonoBehaviour
{
    public GameObject OtherObj;
    public UnityEvent OtherEvent;
    void Start()
    {
        var cv = GetComponent<NPCConversation>();
        ConversationManager.OnConversationEnded += EndCV;
        ConversationManager.Instance.StartConversation(cv);
    }
    
    void EndCV()
    {
        ConversationManager.OnConversationEnded -= EndCV;
        gameObject.SetActive(false); 
        if(OtherObj != null ) OtherObj.SetActive(true);
        if(OtherEvent != null) OtherEvent.Invoke();
    }
}
