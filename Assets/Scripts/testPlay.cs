using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class testPlay : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Application.LoadLevel("Mode1");
        Debug.Log("loaded");
    }
}