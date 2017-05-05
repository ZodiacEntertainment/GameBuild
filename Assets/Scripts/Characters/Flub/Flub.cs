using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flub : ZodiacCharacter {

	public List<AudioClip> clips;
	private AudioSource aSource;

    //controller prefix in parent
    //public string controller;

    // Movement
    private int speed; // Speed tier 1-6
    //private new int coins; // Number of coins 0-15

    // Jump
    [SerializeField]
    public int jumpHeight;
    private bool isGrounded;

    // Status
    //private bool isStunned;
    private bool isInvincible;
    private bool isAlive;

    // Basic Attack
    [SerializeField]
    [Tooltip("How many coins lost when attack hits.")]
    private int bDamage;
    [SerializeField]
    [Tooltip("How long before the attack can be used again.")]
    private int bCoolDown;
    //is using slip trick
    bool slipTrick = false;

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

    public bool haveItem = false;
    private GameObject inventory;
    private bool canAttack = true;

    // Use this for initialization
    void Start () {
		aSource = GetComponent<AudioSource>();
		isStunned = false;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A) && canAttack)
        {
			aSource.PlayOneShot(clips [0]);
            //call anim
            StartCoroutine(SlipTrick());
        }
        if (Input.GetButtonDown("Fire1") && haveItem)
        {
            // Use the pickup
            //Debug.Log("Used " + inventory);
            haveItem = false;
        }
        else if (Input.GetButtonDown("Fire2") && haveItem)
        {
            // Drop the pickup
            inventory.SetActive(true);
            inventory.transform.position = new Vector3(this.gameObject.transform.position.x - 2f, this.gameObject.transform.position.y, inventory.transform.position.z);
            //Debug.Log("Dropped " + inventory);
            haveItem = false;
        }
        if (slipTrick){
            transform.Translate(new Vector3(2,0,0) * Time.deltaTime);
        }
    }
    public IEnumerator SlipTrick(){
        slipTrick = true;
        canAttack = false;
        yield return new WaitForSeconds(bCoolDown);
        canAttack = true;
        slipTrick = false;
    }
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Coin")){
            coins++;
            //Debug.Log("Total Coins = " + coins);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Item") && !haveItem){
            inventory = other.gameObject;
            //Debug.Log("Picked up " + inventory);
            inventory.SetActive(false);
            haveItem = true;
        }
        if (slipTrick){
			other.gameObject.GetComponent<ZodiacCharacter>().TakeDamage(bDamage);
        }
    }
    public override void TakeDamage(int _damage){
		aSource.PlayOneShot (clips [3]);
		coins -= _damage;
        Debug.Log("Coins" + coins);
    }
}
