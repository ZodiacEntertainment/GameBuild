using UnityEngine;
using System.Collections;

public class ItemDrop : MonoBehaviour {

    Vector2 move = new Vector2(0, 0);
    public float HSpeed = 0;
    public float launchForce;

    public void Drop()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, launchForce));
        HSpeed = 3f;
    }
    // Update is called once per frame
    void Update()
    {
        move = new Vector2(-HSpeed, 0f);
        transform.Translate(move * Time.deltaTime);
    }
}
