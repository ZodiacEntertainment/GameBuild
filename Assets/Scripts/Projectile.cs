using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public GameObject owner;
    public int damage;
    public float speed;
    private Vector3 move;

	// Use this for initialization
	void Start () {
        move = new Vector3(speed, 0, 0);
        Destroy(this.gameObject, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(move * Time.deltaTime);
	}

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetInstanceID() != owner.gameObject.GetInstanceID()) {
            switch (other.gameObject.name) {
                case "Alexis":
                    other.gameObject.GetComponent<Alexis>().TakeDamage(damage);
                    break;
                case "Flub":
                    other.gameObject.GetComponent<Flub>().TakeDamage(damage);
                    break;
                case "Tamiel":
                    other.gameObject.GetComponent<Tamiel>().TakeDamage(damage);
                    break;
                case "Mirina":
                    other.gameObject.GetComponent<Mirina>().TakeDamage(damage);
                    break;
                default:
                    Debug.Log(other.gameObject.name);
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
