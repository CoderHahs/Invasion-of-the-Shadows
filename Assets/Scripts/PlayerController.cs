using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public GameObject playerNinjaStar;
	public float starSpeed;
	public float rotationSpeed;
	public Transform playerLaunchPoint;
	public float playerWaitBetweenShots;
	private float playerShotCounter;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator anim;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	public bool canMove;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playerShotCounter = playerWaitBetweenShots;
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	
	// Update is called once per frame
	void Update () {

		if (!canMove) {
			GetComponent<Rigidbody2D>().isKinematic = true;
			return;
		}
		else
		{
			GetComponent<Rigidbody2D>().isKinematic = false;
		}

		playerShotCounter -= Time.deltaTime;

		if (grounded) 
			doubleJumped = false;

		if (Input.GetKeyDown (KeyCode.W) && grounded) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x,jumpHeight);
		}

		if (Input.GetKeyDown (KeyCode.W) && !doubleJumped && !grounded) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jumpHeight);
			doubleJumped = true;
		}

		moveVelocity = 0f;

		if (Input.GetKey (KeyCode.D)) {
			//rigidbody2D.velocity = new Vector2 (moveSpeed,rigidbody2D.velocity.y);
			moveVelocity = moveSpeed;
		}
		if (Input.GetKey (KeyCode.A)) {
			//rigidbody2D.velocity = new Vector2 (-moveSpeed,rigidbody2D.velocity.y);
			moveVelocity = -moveSpeed;
		}

		if (Input.GetKeyDown (KeyCode.K)) {
			anim.SetBool ("ShootNS", true);


			if (playerShotCounter < 0) {
				Instantiate (playerNinjaStar, playerLaunchPoint.position, playerLaunchPoint.rotation);
				playerShotCounter = playerWaitBetweenShots;

			}
			
		} else {
			anim.SetBool("ShootNS", false);
		}



		if (knockbackCount <= 0) {
			rigidbody2D.velocity = new Vector2 (moveVelocity, rigidbody2D.velocity.y);
		} else {
			if (knockFromRight)
				rigidbody2D.velocity = new Vector2 (-knockback, knockback);
			if (!knockFromRight)
				rigidbody2D.velocity = new Vector2 (knockback, knockback);
			knockbackCount -= Time.deltaTime; 
		}

		anim.SetFloat ("Speed", Mathf.Abs(rigidbody2D.velocity.x));

	}
}
