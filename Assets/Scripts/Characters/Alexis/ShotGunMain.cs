using UnityEngine;
using System.Collections;

public class ShotGunMain : MonoBehaviour{
    public GameObject owner;
    public int damage;

    GameObject target;

    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.GetInstanceID() != owner.gameObject.GetInstanceID()){
            target = other.gameObject;
        }
    }

    public void BasicAttack() {
        if(target != null) {
			if (target.tag == "Character" && target.gameObject.GetInstanceID() != owner.gameObject.GetInstanceID()) {
				target.GetComponent<ZodiacCharacter>().TakeDamage(damage);
				Debug.Log (target.GetComponent<Alexis>().controller);
				owner.GetComponent<Alexis> ().AttackUpdate (damage);
			}
        }
    }
}
