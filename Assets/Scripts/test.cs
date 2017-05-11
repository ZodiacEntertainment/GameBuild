using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class test : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Application.LoadLevel(1);
    }
}