using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private const float acceleration = 10f;
    private const float drag = .25f;
    private const float gravity = -1f;
	private bool facingRight = true;
    private const float jumpForce = 1500f;

	private const float maxVelocity = 20;
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

    void LateUpdate()
    {
        //Vector2 gravityForce = Vector2.up * gravity * Time.deltaTime * 1000f;
        //rigidbody2D.AddForce(gravityForce);
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
		//Check for grounding
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

        UpdateMovement();

        //Jumping
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            //Debug.Log(Current.getCurrentItem());
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }

        //Add generic death conditions here


	}

    void UpdateMovement()
    {
        Vector2 velocity = rigidbody2D.velocity;
        float direction = Mathf.Sign(velocity.x);

        if (Input.GetAxis("Horizontal") == 0)
        {
            if (Mathf.Abs(velocity.x) > .0001f)
            {
                Debug.Log("Slowing");
                velocity.x = velocity.x * drag;
                rigidbody2D.velocity = velocity;
            }
            else
            {
                Debug.Log("Stopped");
                velocity.x = 0;
                rigidbody2D.velocity = velocity;
            }
        }
        else
        {
            FaceDirection(direction);
        }

        if (Mathf.Abs(velocity.x) > maxVelocity)
        {
            velocity.x = direction * maxVelocity;
            rigidbody2D.velocity = velocity;
        }
        else
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            Vector2 force = Vector2.right * horizontalMovement * acceleration * Time.deltaTime * 1000f;
            Debug.Log(force.x);
            rigidbody2D.AddForce(force);
        }

        rigidbody2D.velocity = velocity;
    }


	void FaceDirection(float direction)
	{
        if (direction != 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = Mathf.Abs(theScale.x) * direction;
            transform.localScale = theScale;
        }
	}

	public void kill(){
		Application.LoadLevel(Application.loadedLevel);
		}
}
