using UnityEngine;
using UnityEngine.UI;
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
	public GameObject slipCol;

    // Special Attack
    [SerializeField]
    [Tooltip("How many coins lost when attack hits.")]
    public int spDamage;
    [SerializeField]
    [Tooltip("How long the attack lasts.")]
    private int spDuration;
    [SerializeField]
    [Tooltip("How long before the attack can be used again.")]
    private float spCoolDown;
	public GameObject slimeBall;
	public Transform throwPoint;
	GameObject spTemp;

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
	public float InvincTime;
	public UIManager uiMan;
	public float horForce;
	public float vertForce;


    // Use this for initialization
    void Start () {
		transform.GetChild (1).gameObject.SetActive (false);
		aSource = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		isStunned = false;
		isInvincible = false;
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
			aSource.PlayOneShot (clips [6]);
			switch(inventory.GetComponent<SpriteRenderer>().sprite.name){
			case "powerup":
				StartCoroutine (Invincible());
				break;
			default:
				break;
			}
			uiMan.ItemDisplay("Default");
			haveItem = false;
		}
		if ((Input.GetAxis(controller + "ItemDrop") > 0.5f || Input.GetAxis("Fire2") > 0.5f) && haveItem){
			// Drop the pickup
			inventory.transform.position = new Vector3(this.gameObject.transform.position.x - 2.5f, this.gameObject.transform.position.y, inventory.transform.position.z);
			inventory.SetActive(true);
			aSource.PlayOneShot (clips [7]);
			// apply a force to make it move
			GameObject child = inventory.transform.GetChild(0).gameObject;
			Rigidbody2D rb = inventory.GetComponent<Rigidbody2D>();
			child.SetActive(true);
			rb.isKinematic = false;
			rb.AddForce(new Vector2(horForce, vertForce), ForceMode2D.Impulse);
			Debug.Log("Dropped " + inventory);
			uiMan.ItemDisplay("Default");
			haveItem = false;
		}
    }
	public IEnumerator AttackSpecialDelay(){
		canAttackSpecial = false;
		aSource.PlayOneShot (clips [1]);
		spTemp = Instantiate(slimeBall, throwPoint.position, Quaternion.identity) as GameObject;
		spTemp.GetComponent<SlimeBall> ().owner = this.gameObject;
		if (!GetComponent<CharacterMovement>().facingRight)
			spTemp.GetComponent<SlimeBall>().HSpeed *= -1;
		if(GetComponent<SpriteRenderer>().flipY)
			spTemp.GetComponent<SlimeBall> ().launchForce *= -1;
		yield return new WaitForSeconds(spCoolDown);
		canAttackSpecial = true;
	}
	public IEnumerator SlipTrick(){
		slipTrick = true;
		canAttackBasic = false;
		slipCol.SetActive (true);
		aSource.PlayOneShot (clips[0]);
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GetComponent<Collider2D> ().isTrigger = true;
		yield return new WaitForSeconds(bCoolDown);
		canAttackBasic = true;
		slipTrick = false;
		slipCol.SetActive (false);
		GetComponent<Rigidbody2D> ().isKinematic = false;
		GetComponent<Collider2D> ().isTrigger = false;
	}
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Coin")){
            coins++;
			manager.StatUpdate (controller, "MC", 1);
			aSource.PlayOneShot (clips [4]);
            //Debug.Log("Total Coins = " + coins);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Item") && !haveItem){
            inventory = other.gameObject;
			aSource.PlayOneShot (clips [5]);
            //Debug.Log("Picked up " + inventory);
            inventory.SetActive(false);
			uiMan.ItemDisplay(other.GetComponent<SpriteRenderer>().sprite.name);
            haveItem = true;
        }
    }
	public override void TakeDamage(int _damage){
		StartCoroutine (Stun());
		aSource.PlayOneShot (clips [3]);
		anim.SetTrigger ("TakeDamage");
		coins -= _damage;
		Debug.Log("Coins" + coins);
		manager.StatUpdate (controller, "MDT", _damage);
	}

	public IEnumerator Stun(){
		isStunned = true;
		yield return new WaitForSeconds(stunDur);
		isStunned = false;
	}
	public IEnumerator Invincible(){
		isInvincible = true;
		transform.GetChild (1).gameObject.SetActive (true);
		yield return new WaitForSeconds(InvincTime);
		transform.GetChild (1).gameObject.SetActive (false);
		isInvincible= false;
	}
}
