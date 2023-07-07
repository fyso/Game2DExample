using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalk : MonoBehaviour
{
    public GameObject E;
    public GameObject DialogUI;

    public Sprite DialogIcon;
    public TextAsset DialogTextAsset;

    private void Start()
    {
        E.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GameObject().tag == "Player" && DialogTextAsset != null)
        {
            E.SetActive(true);
            DialogUI.GetComponent<DialogSystem>().ChangeDialogText(DialogIcon, DialogTextAsset);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GameObject().tag == "Player")
            E.SetActive(false);
    }

    private void Update()
    {
        if(E.activeSelf && Input.GetKey(KeyCode.E) && DialogTextAsset != null)
        {
            DialogUI.SetActive(true);
        }
    }
}
