using UnityEngine;
using System.Collections;

public class Chariot : MonoBehaviour {

    public CamMove cam;
    public Alexis player;
    public GameObject RightBound;

    public bool isInPosition = true;
    public bool hasTriggered = false;

	// Update is called once per frame
	void Update () {

        if(player.coins >= 10 && !hasTriggered)
        {
            isInPosition = false;
            hasTriggered = true;
        }

        if (isInPosition)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-10, GetComponent<Rigidbody2D>().velocity.y);
        }
        
	}
}
    