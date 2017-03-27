using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;

    void OnMouseUp()
    {
        if (isStart)
        {
            Application.LoadLevel(1);
        }
        if (isQuit)
        {
            Application.Quit();
        }
    }
}