using UnityEngine;
using System.Collections;

public class Chariot : MonoBehaviour {

    public Alexis coinCounter;

    public bool triggered;
    public float maxCoins = 3f;
    public float speed = 0f;

    void Start()
    {
        triggered = false;
    }

	// Update is called once per frame
	void Update () {

        if (coinCounter.coins >= maxCoins)
        {
            triggered = true;
            speed = -10;
        }
        else
            speed = 0;

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

    }
}
    