using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicableManager : MySingleton<ClicableManager>
{
    public GameObject Mask;
    private NPCClickToTalk[] m_NPCTalks;

    void Start()
    {
        m_NPCTalks = FindObjectsOfType<NPCClickToTalk>();
    }

    public void TalkOneNPC(string Name)
    {
        Mask.GetComponent<SpriteRenderer>().sortingOrder = 3;
        foreach (NPCClickToTalk npc in m_NPCTalks)
        {
            if(npc.NPCName == Name)
            {
                npc.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
                npc.gameObject.SetActive(true);
            }
            else
            {
                npc.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
                npc.gameObject.SetActive(false);
            }
        }
    }

    public void EndTalkWithNPC()
    {
        Mask.GetComponent<SpriteRenderer>().sortingOrder = 0;
        foreach (NPCClickToTalk npc in m_NPCTalks)
        {
            npc.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
            npc.gameObject.SetActive(true);
        }
    }
}
