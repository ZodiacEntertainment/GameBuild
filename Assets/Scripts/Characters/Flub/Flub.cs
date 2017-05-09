using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flub : ZodiacCharacter {
	public GameManager manager;

	public List<AudioClip> clips;
	private AudioSource aSource;
	Animator anim;

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
	private float bCoolDown;
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
    private float spCoolDown;

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
	private bool canAttackBasic = true;
	private bool canAttackSpecial = true;
	public float stunDur;
	public UIManager uiMan;


    // Use this for initialization
    void Start () {
		aSource = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		isStunned = false;
		uiMan = myHUD.GetComponent<UIManager>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if ((Input.GetAxis(controller + "BA") > 0.5f || Input.GetKeyDown(KeyCode.J))&& canAttackBasic){
            //call anim
			anim.SetTrigger("BasicAttack");

//			aSource.clip = clips[0];
//			aSource.Play ();
            StartCoroutine(SlipTrick());
        }
		if ((Input.GetAxis(controller + "SpA") > 0.5f  || Input.GetKeyDown(KeyCode.K)) && canAttackSpecial){
			anim.SetTrigger("SpecialAttack");
			StartCoroutine(AttackSpecialDelay());

		}
		if ((Input.GetAxis(controller + "ItemUse") > 0.5f || Input.GetAxis("Fire1") > 0.5f) && haveItem){
			// Use the pickup
			Debug.Log("Used " + inventory);
			uiMan.ItemDisplay("Default");
			haveItem = false;
		}
		if ((Input.GetAxis(controller + "ItemDrop") > 0.5f || Input.GetAxis("Fire2") > 0.5f) && haveItem){
			// Drop the pickup
			inventory.transform.position = new Vector3(this.gameObject.transform.position.x - 2.5f, this.gameObject.transform.position.y, inventory.transform.position.z);
			inventory.SetActive(true);
			Debug.Log("Dropped " + inventory);
			uiMan.ItemDisplay("Default");
			haveItem = false;
		}
        if (slipTrick){
			if (GetComponent<CharacterMovement>().facingRight)
            	transform.Translate(new Vector3(3,0,0) * Time.deltaTime);
			else
				transform.Translate(new Vector3(-3,0,0) * Time.deltaTime);
        }
		CoinUpdate ();
    }
	public IEnumerator AttackSpecialDelay(){
		canAttackSpecial = false;
		yield return new WaitForSeconds(spCoolDown);
		canAttackSpecial = true;
	}
    public IEnumerator SlipTrick(){
        slipTrick = true;
        canAttackBasic = false;
        yield return new WaitForSeconds(bCoolDown);
        canAttackBasic = true;
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
			uiMan.ItemDisplay(other.GetComponent<SpriteRenderer>().sprite.name);
            haveItem = true;
        }
		if (slipTrick && other.CompareTag("Character")){
			other.gameObject.GetComponent<ZodiacCharacter>().TakeDamage(bDamage);
        }
    }
	public override void TakeDamage(int _damage){
		StartCoroutine (Stun());
		anim.SetTrigger ("FlubDamage");
		coins -= _damage;
		Debug.Log("Coins" + coins);
		manager.StatUpdate (controller, "MDT", _damage);
	}

	public IEnumerator Stun(){
		isStunned = true;
		yield return new WaitForSeconds(stunDur);
		isStunned = false;
	}
	public override void  CoinUpdate (){
		if(coins == coinTier1)
			coinLevel = 1;
		if (coins == coinTier2)
			coinLevel = 2;
		if (coins == coinTier3)
			coinLevel = 3;
		if (coins == coinTier4)
			coinLevel = 4;
		if (coins == coinTier5)
			coinLevel = 5;
		if (coins == coinMax)
			coinLevel = 6;

	}
}
