using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float maxSpeed = 25;
	private bool facingRight = true;
	public float jumpForce = 1500f;
	Animator anim;

	//Falling Setup, check for ground etc
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 1f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}



	// Update is called once per frame
	void FixedUpdate () {


		//Check for grounding
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);


		//Horizontal Movement
		float horizontalMovement = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs (horizontalMovement));
		rigidbody2D.velocity = new Vector2(horizontalMovement * maxSpeed, rigidbody2D.velocity.y);
		if(horizontalMovement > 0 && !facingRight)
			Flip();
		else if (horizontalMovement < 0 && facingRight)
			Flip();
	}

	void Update(){
		//Jumping
		if (grounded && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool ("Ground",false);
			//Debug.Log(Current.getCurrentItem());
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

		//Add generic death conditions here


	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void kill(){
		Application.LoadLevel(Application.loadedLevel);
		}
}
