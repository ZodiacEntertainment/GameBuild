using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed = 10f;
    public float currSpeed = 10f;
	public bool facingRight = true;
	public AudioClip jumpClip;

	private AudioSource jumpSource;

    Animator anim;

    //bool to store if on ground
    bool grounded = false;
    //radius of circle within with the character checks for ground
    public float groundRadius = .8f;
    //var to determine what objects are considered 'ground'
    public LayerMask whatIsGround;
    public Vector2 groundCheck1;
    public Vector2 groundCheck2;
    public float offset = .77f;
    public float jumpForce = 1000f;
	public float fallCap;

    //tell me if jumping
    public static bool jumping = true;

    public float JumpForce { get; private set; }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
		jumpSource = GetComponent<AudioSource> ();
        
    }

    // Update is called once per frame
    void Update()
    {   
        //set origin point for raycast
        groundCheck1.x = gameObject.transform.position.x + offset;
        groundCheck2.x = gameObject.transform.position.x - offset;
        groundCheck1.y = gameObject.transform.position.y;
        groundCheck2.y = gameObject.transform.position.y;

        //reduce speed when not on the ground because otherwise it feels too slippery
        if(!grounded && !jumping)
        {
            jumping = true;
            currSpeed -= 2;
        }

        if (grounded && jumping)
        {
            jumping = false;
            currSpeed = speed;
        }

        //SAME FOR THIS
        if (grounded && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            currSpeed += 5;
        }

        if (grounded && !jumping && (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)))
        {
            currSpeed = speed;
        }
		//REMEMBER TO CHANGE KEYCODE.SPACE TO A REMAPABLE KEY LATER
		if (grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			jumpSource.clip = jumpClip;
			jumpSource.Play();
		}

    }

    //Method both changes values of currSpeed to positive or negative values to make char go right or left, respectively,
    //and flips the sprite to face left or right.
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FixedUpdate () {
		
        //check if player is on ground
        if (Physics2D.Raycast(groundCheck1, Vector2.down, groundRadius, whatIsGround) || Physics2D.Raycast(groundCheck2, Vector2.down, groundRadius, whatIsGround)) grounded = true;
        else grounded = false;

        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        //get direction of arrow key pressed (also works with wasd)
		float move = Input.GetAxis ("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * currSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
}
