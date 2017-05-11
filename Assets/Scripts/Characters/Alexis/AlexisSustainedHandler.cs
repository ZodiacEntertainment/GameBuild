using UnityEngine;
using System.Collections;

public class AlexisSustainedHandler : MonoBehaviour {

	Alexis myRef;
	// Use this for initialization
	void Start () {
		myRef = gameObject.GetComponentInParent<Alexis> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (myRef.isSusAttacking && other.gameObject.CompareTag ("Character")) {
			if(!other.GetComponent<ZodiacCharacter>().isStunned  && !other.GetComponent<ZodiacCharacter> ().isInvincible)
			other.GetComponent<ZodiacCharacter> ().TakeDamage (myRef.hDamage);
		}
	}
}
