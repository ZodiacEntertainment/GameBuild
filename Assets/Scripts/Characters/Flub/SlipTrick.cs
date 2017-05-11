using UnityEngine;
using System.Collections;

public class SlipTrick : MonoBehaviour {
	public int Damage;

	public void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Character")) {
			if (!other.GetComponent<ZodiacCharacter> ().isStunned && !other.GetComponent<ZodiacCharacter> ().isInvincible)
				other.GetComponent<ZodiacCharacter> ().TakeDamage (Damage);
		}
	}
}
