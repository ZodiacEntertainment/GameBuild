using UnityEngine;
using System.Collections;

public class Chariot : MonoBehaviour {

    public CamMove cam;
    public Alexis coinCounter;
    public GameObject RightBound;

   public  bool triggered;

    public float maxCoins = 3f;

    void Start()
    {
        triggered = false;
    }

	// Update is called once per frame
	void Update () {

        if(coinCounter.coins >= maxCoins)
        {
            triggered = true;
        }

        if (triggered)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-10, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
        
	}
}
    