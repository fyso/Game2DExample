using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveJudge : MonoBehaviour
{
    public int RealFinalIdnex, FakeFinalIndex;
    public void Leave()
    {
        if(BagUI.instance.ItemIDs.Count > 0)
        {
            SceneUtility.Instance.ChangeSceneByIndex(RealFinalIdnex);
        }
        else
            SceneUtility.Instance.ChangeSceneByIndex(FakeFinalIndex);
    }
}
