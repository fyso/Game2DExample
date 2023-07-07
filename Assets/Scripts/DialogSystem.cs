using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI m_DialogText;
    public float TextSpeed = 0.1f;

    public Image m_DialogIcon;
    private TextAsset m_DialogTextAsset;
    private List<string> m_DialogTestList = new List<string>();
    private int m_CurrTextIndex;
    private bool TextLineFinish;

    void Start()
    {
        m_DialogText = GetComponentInChildren<TextMeshProUGUI>();
        m_CurrTextIndex = 0;
    }

    private void OnEnable()
    {
        TextLineFinish = true;
        StartCoroutine(SetTextUI());
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && m_CurrTextIndex == m_DialogTestList.Count)
        {
            m_CurrTextIndex = 0;
            gameObject.SetActive(false);
        }
        
        if (Input.GetKeyUp(KeyCode.E) && TextLineFinish)
        {
            //m_DialogText.text = m_DialogTestList[m_CurrTextIndex];
            //m_CurrTextIndex++;
            StartCoroutine(SetTextUI());
        }
    }

    public void ChangeDialogText(Sprite vDialogIcon, TextAsset vTextAsset)
    {
        m_DialogIcon.sprite = vDialogIcon;
        m_DialogTextAsset = vTextAsset;

        GetTextFromAsset(m_DialogTextAsset);
    }

    private void GetTextFromAsset(TextAsset vTextAsset)
    {
        m_DialogTestList.Clear();
        m_CurrTextIndex = 0;

        var LineData = vTextAsset.text.Split('\n');
        foreach(var line in LineData)
        {
            m_DialogTestList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        m_DialogText.text = "";
        TextLineFinish = false;
        for (int i = 0; i< m_DialogTestList[m_CurrTextIndex].Length; i++)
        {
            m_DialogText.text += m_DialogTestList[m_CurrTextIndex][i];
            yield return new WaitForSeconds(TextSpeed);
        }
        TextLineFinish = true;
        m_CurrTextIndex++;
    }
}
