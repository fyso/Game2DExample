using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicableManager : MySingleton<SceneUtility>
{
    public NPCClickToTalk[] m_NPCTalks;

    void Start()
    {
        m_NPCTalks = FindObjectsOfType<NPCClickToTalk>();
    }

    public void TalkOneNPC(string Name)
    {

    }

    public void EndTalkWithNPC()
    {

    }
}
