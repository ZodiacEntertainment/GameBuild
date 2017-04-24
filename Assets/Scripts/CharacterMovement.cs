using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed = 10f;
    public float currSpeed = 10f;
	public bool facingRight = true;

    Animator anim;
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

    public float JumpForce { get; private set; }

    SpriteRenderer sprite;
	GameObject blastArea;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
		if (GetComponent<Alexis> () != null) {
			blastArea = GetComponent<Alexis> ().BlastArea;
		}
    }

    // Update is called once per frame
    void Update()
    {   
        //set origin point for raycast
        groundCheck1.x = gameObject.transform.position.x + rightOffset;
        groundCheck2.x = gameObject.transform.position.x - leftOffset;
        groundCheck1.y = gameObject.transform.position.y;
        groundCheck2.y = gameObject.transform.position.y;

        //sprint when holding shift
		if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) || Input.GetAxis(controller + "Run") > 0f)
        {
            currSpeed += runSpeed;
        }

		if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift) || Input.GetAxis(controller + "Run") == 0f)
        {
            currSpeed = speed;
        }

        //Jump when jump key is held
		//REMEMBER TO CHANGE KEYCODE.SPACE TO A REMAPABLE KEY LATER
		if (grounded && Input.GetAxis(controller + "Jump") > 0.5f || Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}

    }

    //Method both changes values of currSpeed to positive or negative values to make char go right or left, respectively,
    //and flips the sprite to face left or right.
    void Flip()
    {
        facingRight = !facingRight;
        sprite.flipX = !facingRight;
		if (GetComponent<Alexis> () != null) {
			if (facingRight)
				blastArea.transform.position = new Vector3 (transform.position.x - 1, blastArea.transform.position.y, blastArea.transform.position.z);
			else
				blastArea.transform.position = new Vector3 (transform.position.x + 1, blastArea.transform.position.y, blastArea.transform.position.z);
		}
       // Vector3 theScale = transform.localScale;
       // theScale.x *= -1;
       // transform.localScale = theScale;
    }

    void FixedUpdate () {
		
        //check if player is on ground
        if (Physics2D.Raycast(groundCheck1, Vector2.down, groundRadius, whatIsGround) || Physics2D.Raycast(groundCheck2, Vector2.down, groundRadius, whatIsGround)) grounded = true;
        else grounded = false;

        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        //get direction of arrow key pressed (also works with wasd)
		float move = Input.GetAxis (controller + "Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * currSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
}
