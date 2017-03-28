using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Alexis : MonoBehaviour {

	public List<AudioClip> clips;
	private AudioSource aSource;

    //controller prefix
    public string controller;

    // Movement
    private int speed; // Speed tier 1-6
    public int coins = 0; // Number of coins 0-15

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
    //main AOE
	public GameObject BlastArea;

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

    [HideInInspector]
    public bool haveItem = false;
    private GameObject inventory;
	private float delay;

    private bool canAttack = true;


    // Use this for initialization
    void Start () {
		aSource = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		//basic attack
        if (Input.GetKeyDown(KeyCode.J) && canAttack) {
            BlastArea.GetComponent<ShotGunMain>().BasicAttack();
            //call anim
			aSource.clip = clips[0];
			aSource.Play ();
			delay = bCoolDown;
            StartCoroutine(AttackDelay());
        }
		// special attack
		if (Input.GetKeyDown (KeyCode.K) && canAttack) {
			
		}
        if (Input.GetButtonDown("Fire1") && haveItem){
            // Use the pickup
            Debug.Log("Used " + inventory);
            haveItem = false;
        }
        else if (Input.GetButtonDown("Fire2") && haveItem){
            // Drop the pickup
            inventory.transform.position = new Vector3(this.gameObject.transform.position.x - 2.5f, this.gameObject.transform.position.y, inventory.transform.position.z);
            inventory.SetActive(true);
            Debug.Log("Dropped " + inventory);
            haveItem = false;
        }
    }
    public IEnumerator AttackDelay(){
        canAttack = false;
		yield return new WaitForSeconds(delay);
        canAttack = true;
    }
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Coin")){
            coins++;
            //Debug.Log("Total Coins = " + coins);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Item") && !haveItem){
            inventory = other.gameObject;
            Debug.Log("Picked up " + inventory);
            inventory.SetActive(false);
            haveItem = true;
        }
    }
    public void TakeDamage(int _damage){
        coins -= _damage;
		aSource.clip = clips [1];
		aSource.Play ();
        Debug.Log("Coins" + coins);
    }
}
