using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public GameObject owner;
    public int damage;
    public float speed;
    private Vector3 move;

	// Use this for initialization
	void Start () {
        move = transform.right;
        //move = new Vector3(speed, 0, 0);
        Destroy(this.gameObject, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(move * Time.deltaTime);
	}

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetInstanceID() != owner.gameObject.GetInstanceID()) {
			if (other.tag == "Character"){
				other.gameObject.GetComponent<ZodiacCharacter> ().TakeDamage (damage);
			}
            Destroy(this.gameObject);
        }
    }
}
