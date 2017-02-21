using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    //weapon holder weapon
    private Character owner;
    //ref to attack
    public Collider2D other;
    //Damage of melee attacks
    public float meleeDamage;
    //vars for attack/damgae control
    private bool isAttacking = false;
    private bool canDamage = false;

    void Start(){
        owner = gameObject.GetComponentInParent<Character>();
    }

    void Update() {
        if (isAttacking){
            if (other != null){
                other.gameObject.GetComponent<Character>().TakeDamage(meleeDamage);
                canDamage = false;
            }
            if (transform.rotation.z < 90){
                transform.Rotate(new Vector3(0, 0, -90) * Time.deltaTime);
            }
            if (transform.rotation.z >= 90) {
                transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D _other){
        if (other.tag == "Character" && other.GetComponent<Character>() != owner){
            other = _other;
        }
    }

    public void OnTriggerExit2D(Collider2D _other){
        if (other.tag == "Character" && other.GetComponent<Character>() != owner){
            other = null;
        }
    }
    public void Attack(){
        isAttacking = true;
        canDamage = true;
    }
}
