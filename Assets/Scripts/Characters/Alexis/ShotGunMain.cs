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
            switch (target.name){
                case "Alexis":
                    target.gameObject.GetComponent<Alexis>().TakeDamage(damage);
                    break;
                case "Flub":
                    target.gameObject.GetComponent<Flub>().TakeDamage(damage);
                    break;
                default:
                    //Debug.Log(target.gameObject.name);
                    break;
            }
        }
    }
}
