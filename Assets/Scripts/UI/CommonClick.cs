using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CommonClick : MonoBehaviour
{
    public GameObject DisplayText;
    private void Awake()
    {
       var button = GetComponent<Button>();
        if(button != null)
        {
            button.onClick.AddListener(TriggerFunc);
        }
    }
    public void TriggerFunc()
    {
        if(DisplayText != null)
        {
            //½ö²âÊÔ
            DisplayText.SetActive(true);
            Debug.Log("Click");
        }
    }
}
