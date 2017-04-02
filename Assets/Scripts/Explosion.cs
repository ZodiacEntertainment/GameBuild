using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public int damage;
	public GameObject owner;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 0.5f);
	
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Character" && other.gameObject.GetInstanceID() != owner.gameObject.GetInstanceID()) {
			GetComponent<Character>().TakeDamage(damage);
		}
	}
}
