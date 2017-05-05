using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Alexis : ZodiacCharacter {
	public GameManager manager;

	public List<AudioClip> clips;
	public List<AudioClip> dmgTknClips;
	private AudioSource aSource;
	private Animator anim;

    //controller prefix in parent
    //public string controller;

    // Movement
    private int speed; // Speed tier 1-6
    //public int coins = 0; // Number of coins 0-15

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
    //main AOE
	public GameObject BlastArea;

    // Special Attack
    [SerializeField]
    [Tooltip("How many coins lost when attack hits.")]
    private int spDamage;
    [SerializeField]
    [Tooltip("How long the attack lasts.")]
    private int spDuration;
    

	public GameObject granade;
	public Transform launchPoint;

    // Sustained Attack
    [SerializeField]
    [Tooltip("How many coins lost when attack hits.")]
    public int hDamage;
	public bool isSusAttacking = false;

    [HideInInspector]
    public bool haveItem = false;
    private GameObject inventory;

	public float delayBasic;
    public float delaySpecial;
    public float spCooldown;
    GameObject temp;

    private bool canAttackBasic = true;
    private bool canAttackSpecial = true;
	public float stunDur;
	public UIManager uiMan;

    // Use this for initialization
    void Start () {
		aSource = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		uiMan = myHUD.GetComponent<UIManager>();
		isStunned = false;
    }
	// Update is called once per frame
	void FixedUpdate () {
		if(!isStunned){
			//basic attack
			if ((Input.GetAxis(controller + "BA") > 0.5f || Input.GetKeyDown(KeyCode.J))&& canAttackBasic) {
        	    BlastArea.GetComponent<ShotGunMain>().BasicAttack();
            	//call anim
				anim.SetTrigger("BasicAttack");
				aSource.clip = clips[0];
				aSource.Play ();
				//manager.StatUpdate (controller, "Attacks", bDamage);
            	StartCoroutine(AttackBasicDelay());
	        }
			// special attack
			if ((Input.GetAxis(controller + "SpA") > 0.5f  || Input.GetKeyDown(KeyCode.K)) && canAttackSpecial) {
                canAttackSpecial = false;
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

			if(Input.GetAxis(controller + "SuA") > 0f){
				anim.SetBool ("SustainedAttack", true);
				isSusAttacking = true;
				Debug.Log ("SusAttacking start");
			}
			else{
				isSusAttacking = false;
				anim.SetBool ("SustainedAttack", false);
				Debug.Log ("SusAttacking end");
			}
		}
    }
    public IEnumerator AttackBasicDelay(){
        canAttackBasic = false;
		yield return new WaitForSeconds(delayBasic);
        canAttackBasic = true;
    }
    public IEnumerator AttackSpecialDelay()
    {
        
        anim.SetTrigger("SpecialAttack");
        yield return new WaitForSeconds(delaySpecial);
        temp = Instantiate(granade, launchPoint.position, Quaternion.identity) as GameObject;
        temp.GetComponent<Grenade>().owner = this.gameObject;
        if (!GetComponent<CharacterMovement>().facingRight)
            temp.GetComponent<Grenade>().HSpeed *= -1;
        aSource.clip = clips[1];
        aSource.Play();
        yield return new WaitForSeconds(spCooldown);
        canAttackSpecial = true;
    }
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Coin")){
            coins++;
			manager.StatUpdate (controller, "MC", 1);
            //Debug.Log("Total Coins = " + coins);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Item") && !haveItem){
            inventory = other.gameObject;
            Debug.Log("Picked up " + inventory);
			uiMan.ItemDisplay(other.GetComponent<SpriteRenderer>().sprite.name);
            inventory.SetActive(false);
            haveItem = true;
        }
    }
	public override void TakeDamage(int _damage){
		StartCoroutine (Stun());
		anim.SetTrigger ("TakeDamage");
		int i = Random.Range (0, 4);
		coins -= _damage;
		aSource.clip = dmgTknClips[i];
		aSource.Play ();
        Debug.Log("Coins" + coins);
		manager.StatUpdate (controller, "MDT", _damage);
		Debug.Log ("Damage Taken Track " + i);
    }
	public void AttackUpdate(int amount){
		manager.StatUpdate (controller, "MDG", amount);
	}
	public IEnumerator Stun(){
		isStunned = true;
		yield return new WaitForSeconds(stunDur);
		isStunned = false;
	}
}
