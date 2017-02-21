using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float damage;
    public float speed;
    private Vector3 move;

	// Use this for initialization
	void Start () {
        move = new Vector3(speed, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(move);
	}

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Character"){
            other.gameObject.GetComponent<Character>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
