using UnityEngine;
using System.Collections;

public class ShotGunMain : MonoBehaviour{
    public GameObject owner;
    public int damage;

    GameObject target;

    public void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Character")
			if (other.gameObject.GetInstanceID() != owner.gameObject.GetInstanceID() && !other.GetComponent<ZodiacCharacter> ().isInvincible  && !other.GetComponent<ZodiacCharacter> ().isStunned){
            	target = other.gameObject;
        	}
    }
	public void OnTriggerExit2D (Collider2D other){
		if(target != null)
			if (other.gameObject.GetInstanceID () == target.gameObject.GetInstanceID ()) {
				target = null;
			}
	}

    public void BasicAttack() {
        if(target != null) {
			if (target.tag == "Character" && target.gameObject.GetInstanceID() != owner.gameObject.GetInstanceID()) {
				target.GetComponent<ZodiacCharacter>().TakeDamage(damage);
				//Debug.Log (target.GetComponent<Alexis>().controller);
				owner.GetComponent<Alexis> ().AttackUpdate (damage);
			}
        }
    }
}
