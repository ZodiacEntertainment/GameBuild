using UnityEngine;
using System.Collections;

public class CheckForCharacter : MonoBehaviour {
    public GameObject button;
    public GameObject falseButton;
    public GameManager manager;

	// Use this for initialization
	void Start () {
        button.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if(manager.p1 == null && manager.p2 == null && manager.p3 == null && manager.p4 == null){
            button.SetActive(false);
            falseButton.SetActive(true);
        }
        else
        {
            button.SetActive(true);
            falseButton.SetActive(false);
        }
	}
}
