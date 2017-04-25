using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public GameObject ui;
    public GameObject player;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Alexis alexis = player.GetComponent<Alexis>();
        Text score = ui.GetComponent<Text>();
        score.text = "Coins: " + alexis.coins;
    }
}
