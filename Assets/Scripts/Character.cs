using UnityEngine;
using System.Collections;

[System.Serializable]
public class Character : MonoBehaviour {

	//character Name
    public string charName = "";
	//Input combat type
    public string attackType; // Melee or ranged
	//Direction character is faceing && attacking
    private bool facing = true;  // right = true
    public GameObject rangedAttack;
	//ref to attackCheck child
	private Weapon _weapon;
    //Health
    public float health;
    //Damage of ranged attacks
    public float rangedDamage;
    //Attack reload time vars
    public float attackDelay;
    private bool canAttack = false;
    private GameObject temp;
    public float delay1;
    public Vector3 offset;
    public GameObject weapon;


	// Use this for initialization
	void Start () {
    }
    void FixedUpdate(){
        if (facing){
            weapon.transform.position = gameObject.transform.position + offset;
        }
        else{
            weapon.transform.position = gameObject.transform.position - offset;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            switch (attackType) {
                case "Melee":
                    if (canAttack){
                        StartCoroutine(Melee());
                        StartCoroutine(AttackDelay());
                    }
                    break;
                //case "Ranged":
                //    if (canAttack) {
                //        temp = Instantiate(rangedAttack,attackDir, Quaternion.identity) as GameObject;
                //        temp.GetComponent<Projectile>().damage = rangedDamage;
                //        StartCoroutine(AttackDelay());
                //    }
                //    break;
                default:
                    break;
            }
        }
    }
    public IEnumerator AttackDelay() {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    public IEnumerator Melee() {
        _weapon.Attack();
        yield return new WaitForSeconds(delay1);
        canAttack = true;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        //
    }

    public void TakeDamage(float _damage) {
        health -= _damage;
    }
}
