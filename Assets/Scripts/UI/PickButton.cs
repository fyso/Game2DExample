using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickButton : CoversationButton,IPointerEnterHandler,IPointerExitHandler
{
    public AudioClip AudioFile;
    [Header("��Ʒ����")]
    public string ItemID;
    public override bool TryPlayConversation()
    {
        if (base.TryPlayConversation())
        {
            BagUI.instance.ShowItem(ItemID);
            gameObject.SetActive(false);
            if (AudioFile != null)
            {
                GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(AudioFile);
            }
            return true;
        }
        return false;
    }
    private bool hasMouseChange = false;

    private void OnDisable()
    {
        if (hasMouseChange)
        {
            hasMouseChange = false;
            Cursor.SetCursor(GameManager.Instance.OriCursorTex, Vector2.zero, CursorMode.Auto);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hasMouseChange = true;
        Cursor.SetCursor(GameManager.Instance.CursorTex, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hasMouseChange = false;
        Cursor.SetCursor(GameManager.Instance.OriCursorTex, Vector2.zero, CursorMode.Auto);
    }
}
