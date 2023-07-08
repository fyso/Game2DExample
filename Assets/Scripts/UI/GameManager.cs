using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private int MaxClickNum = 4;
    private int ClickNum = 0;
    public List<GameObject> Scenes;
    private int currentSceneIndex = 0;
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
    }
    
    public bool TryClick()
    {
        if(ClickNum + 1>= MaxClickNum) return false;
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
