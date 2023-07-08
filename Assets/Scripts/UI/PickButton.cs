using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickButton : CoversationButton
{
    [Header("ÎïÆ·Ãû³Æ")]
    public string ItemID;
    public override bool TryPlayConversation()
    {
        if (base.TryPlayConversation())
        {
            BagUI.Instance.ShowItem(ItemID);
            return true;
        }
        return false;
    }
}
