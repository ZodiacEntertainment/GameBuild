using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed = 10f;
    public float currSpeed = 10f;
	public bool facingRight = true;
	public AudioClip jumpClip;

	//private AudioSource jumpSource;
	public AudioSource mvmtSource;

    public Animator anim;
	public string controller;

    //bool to store if on ground
    public bool grounded = false;
    //radius of circle within with the character checks for ground
    public float groundRadius = .8f;
    //var to determine what objects are considered 'ground'
    public LayerMask whatIsGround;
    public Vector2 groundCheck1;
    public Vector2 groundCheck2;
    public float leftOffset = .77f;
    public float rightOffset = .77f;
    public float jumpForce = 1000f;
	public float runSpeed;
	public float runSoundDelay;
	public bool runSoundPlaying;

    public float JumpForce { get; private set; }

    SpriteRenderer sprite;
	GameObject blastArea;
	Transform launchPoint;

	public float jumpMult;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
		if (GetComponent<Alexis> () != null) {
			blastArea = GetComponent<Alexis> ().BlastArea;
			launchPoint = GetComponent<Alexis> ().launchPoint;
		}
		mvmtSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {   
        //set origin point for raycast
        groundCheck1.x = gameObject.transform.position.x + rightOffset;
        groundCheck2.x = gameObject.transform.position.x - leftOffset;
        groundCheck1.y = gameObject.transform.position.y;
        groundCheck2.y = gameObject.transform.position.y;
		if (!GetComponent<ZodiacCharacter> ().isStunned) {
			//sprint when holding shift
			if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.RightShift) || Input.GetAxis (controller + "Run") > 0f) {
				if (currSpeed == speed)
					currSpeed = runSpeed + currSpeed;
			}

			if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyUp (KeyCode.RightShift) || Input.GetAxis (controller + "Run") == 0f) {
				currSpeed = speed;
			}

			//Jump when jump key is held
			//REMEMBER TO CHANGE KEYCODE.SPACE TO A REMAPABLE KEY LATER
			if (grounded && Input.GetKeyDown (KeyCode.Space)) {
				anim.SetBool ("Ground", false);
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce * jumpMult));
				mvmtSource.PlayOneShot(jumpClip);
			}
			if (Input.GetAxis (controller + "Jump") > 0f) {
				anim.SetBool ("Ground", false);
				mvmtSource.PlayOneShot(jumpClip);
				if (GetComponent<SpriteRenderer> ().flipY) {
					GetComponent<SpriteRenderer> ().flipY = false;
					GetComponent<Rigidbody2D> ().gravityScale = 2;
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -jumpForce/2f));
				}
				else
					if(grounded) 
						GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
			}
		}
    }

    //Method both changes values of currSpeed to positive or negative values to make char go right or left, respectively,
    //and flips the sprite to face left or right.
    void Flip()
    {
        facingRight = !facingRight;
        sprite.flipX = !facingRight;
		if (GetComponent<Alexis> () != null) {
			if (facingRight) {
				blastArea.transform.position = new Vector3 (transform.position.x + 1, blastArea.transform.position.y, blastArea.transform.position.z);
				launchPoint.position = new Vector3 (transform.position.x + 1, launchPoint.position.y, launchPoint.position.z);
				blastArea.transform.localScale = new Vector3(1,1,1);
			} else {
				blastArea.transform.position = new Vector3 (transform.position.x - 1, blastArea.transform.position.y, blastArea.transform.position.z);
				launchPoint.position = new Vector3 (transform.position.x - 1, launchPoint.position.y, launchPoint.position.z);
				blastArea.transform.localScale = new Vector3(-1,1,1);
			}
		}
       // Vector3 theScale = transform.localScale;
       // theScale.x *= -1;
       // transform.localScale = theScale;
    }

    void FixedUpdate () {
		//climbcheck
		if (GetComponent<Flub> () != null && Input.GetAxis(controller + "SuA") > 0f) {
			if (Physics2D.Raycast (transform.position, transform.up, groundRadius, whatIsGround)) {
				GetComponent<SpriteRenderer> ().flipY = true;
				GetComponent<Rigidbody2D> ().gravityScale = -0.5f;
					
			}
			if (!Physics2D.Raycast (transform.position, transform.right * -1, groundRadius, whatIsGround) && !Physics2D.Raycast (transform.position, transform.up, groundRadius, whatIsGround) && !Physics2D.Raycast (transform.position, transform.right, groundRadius, whatIsGround)) {
				//transform.rotation = Quaternion.Euler(0,0,0);
				GetComponent<SpriteRenderer> ().flipY = false;
				GetComponent<Rigidbody2D> ().gravityScale = 2;
			}
		}
		if (GetComponent<Flub> () != null && Input.GetAxis (controller + "SuA") == 0f) {
			GetComponent<SpriteRenderer> ().flipY = false;
			GetComponent<Rigidbody2D> ().gravityScale = 2;
		}
		//check if player is on ground
		if (Physics2D.Raycast(groundCheck1, Vector2.down, groundRadius, whatIsGround) || Physics2D.Raycast(groundCheck2, Vector2.down, groundRadius, whatIsGround))
			grounded = true;
		else 
			grounded = false;

		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);
		if (!GetComponent<ZodiacCharacter> ().isStunned) {
			float move = 0;
			//get direction of arrow key pressed (also works with wasd)
			if (Input.GetAxis (controller + "Horizontal") > 0f)
				move = Input.GetAxis (controller + "Horizontal");
			if (Input.GetAxis (controller + "Horizontal") < 0f)
				move = Input.GetAxis (controller + "Horizontal");
			if (GetComponent<SpriteRenderer> ().flipY && Input.GetAxis (controller + "Horizontal") < 0f) {
				anim.Play("wallClimb",-1,0f);
				move = Input.GetAxis (controller + "Horizontal");
			} else {
				anim.SetFloat ("Speed", Mathf.Abs (move));
			}
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * currSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();
		}
		if(grounded == true){
			if (Input.GetAxis (controller + "Horizontal") != 0f && !runSoundPlaying) {
				runSoundPlaying = true;
				StartCoroutine (RunSound ());
			} else if(Input.GetAxis (controller + "Horizontal") == 0f) {
				mvmtSource.Stop ();
			}
		}
	}
	IEnumerator RunSound(){
		mvmtSource.Play();
		yield return new WaitForSeconds (runSoundDelay);
		runSoundPlaying = false;
	}
}
