using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed = 10f;
    public float currSpeed = 10f;
	bool facingRight = true;

    Animator anim;

    //bool to stor if on ground
    bool grounded = false;
    public Transform groundCheck;
    //radius of circle within with the character checks for ground
    float groundRadius = 0.2f;
    //var to determine what objects are considered 'ground'
    public LayerMask whatIsGround;

    public float jumpForce = 0.5f;

    //tell me if jumping
    public static bool jumping = true;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        //REMEMBER TO CHANGE KEYCODE.SPACE TO A REMAPABLE KEY LATER
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        //reduce speed when not on the ground because otherwise it feels too slippery
        if(!grounded && !jumping)
        {
            jumping = true;
            currSpeed -= 5;
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
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
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
