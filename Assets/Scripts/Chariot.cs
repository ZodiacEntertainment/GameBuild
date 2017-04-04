using UnityEngine;
using System.Collections;

public class Chariot : MonoBehaviour {

    public CamMove cam;
    public Alexis player;
    public GameObject RightBound;

    public bool isInPosition;
    public bool hasTriggered;

	// Update is called once per frame
	void Update () {

        if(player.coins >= 15 && !hasTriggered)
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
    