using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickButton : CoversationButton
{
    [Header("��Ʒ����")]
    public string ItemID;
    public override bool TryPlayConversation()
    {
        if (base.TryPlayConversation())
        {
            BagUI.instance.ShowItem(ItemID);
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
