using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MySingleton<GameManager>
{
    public Texture2D CursorTex,OriCursorTex;
    public List<GameObject> SmokeMasks;

    private int MaxClickNum = 15555;
    private int ClickNum = 0;
    public List<GameObject> Scenes;
    private int currentSceneIndex = 0;
    override protected void Awake()
    {
        base.Awake();
        if(CursorTex == null)
        {
            Debug.LogError("Resources Wrong");
        }
    }
    public void ChangeScene(int sceneIndex)
    {
        if(sceneIndex < 0 || sceneIndex >= Scenes.Count)
        {
            return;
        }
        Scenes[currentSceneIndex].SetActive(false);
        Scenes[sceneIndex].SetActive(true);
        ResetClickNum(3);
    }

    //切换场景时调用
    private void ResetClickNum(int maxClickNum)
    {
        MaxClickNum = maxClickNum;
        ClickNum = 0;
        /*
        foreach(GameObject obj in SmokeMasks)
        {
            obj.SetActive(false);
        }*/
    }
    
    public bool TryClick()
    {
        if(ClickNum >= MaxClickNum) return false;
        /*
        if (ClickNum < SmokeMasks.Count) SmokeMasks[ClickNum].SetActive(true);
        else Debug.LogWarning("Somke Mask Wrong");
        */

        ClickNum++;
        return true;
    }

    public void ClickNumRunOut()
    {
        //禁止其他除门以外的其他交互 播放提示
        var failTalk = GetComponent<NPCConversation>();
        ConversationManager.Instance.StartConversation(failTalk);
    }
}
