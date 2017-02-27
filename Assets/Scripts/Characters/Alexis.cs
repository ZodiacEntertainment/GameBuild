using UnityEngine;
using System.Collections;

public class Alexis : MonoBehaviour {

    //character Name
    public string charName = "";

    // Movement
    private int speed; // Speed tier 1-6
    private int coins; // Number of coins 0-15

    // Jump
    [SerializeField]
    public int jumpHeight;
    private bool isGrounded;

    // Status
    private bool isStunned;
    private bool isInvincible;
    private bool isAlive;

    // Basic Attack
    [SerializeField]
    [Tooltip("How many coins lost when attack hits.")]
    private int bDamage;
    [SerializeField]
    [Tooltip("How long before the attack can be used again.")]
    private int bCoolDown;

    // Special Attack
    [SerializeField]
    [Tooltip("How many coins lost when attack hits.")]
    private int spDamage;
    [SerializeField]
    [Tooltip("How long the attack lasts.")]
    private int spDuration;
    [SerializeField]
    [Tooltip("How long before the attack can be used again.")]
    private int spCoolDown;

    // Sustained Attack
    [SerializeField]
    [Tooltip("How many coins lost when attack hits.")]
    private int hDamage;

    // Ultimate Attack
    [SerializeField]
    [Tooltip("How many coins lost when attack hits.")]
    private int ultDamage;
    [SerializeField]
    [Tooltip("How long the attack lasts.")]
    private int ultDuration;
    [SerializeField]
    [Tooltip("How long before the attack can be used again.")]
    private int ultCoolDown;

    public GameObject rangedAttack;
    public float attackDelay;
    private bool canAttack = true;
    GameObject temp;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (canAttack){
                temp = Instantiate(rangedAttack, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.25f, transform.position.z), Quaternion.identity) as GameObject;
                temp.GetComponent<Projectile>().owner = this.gameObject;
                temp = Instantiate(rangedAttack, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.25f, transform.position.z), Quaternion.identity) as GameObject;
                temp.GetComponent<Projectile>().owner = this.gameObject;
                StartCoroutine(AttackDelay());
                temp = null;
            }
        }
    }
    public IEnumerator AttackDelay(){
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    public void OnTriggerEnter2D(Collider2D other){
        //
    }

    public void TakeDamage(int _damage){
        coins -= _damage;
        Debug.Log("Coins" + coins);
    }
}
