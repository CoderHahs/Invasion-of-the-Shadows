using UnityEngine;
using System.Collections;

public class PharoahAI : MonoBehaviour {
	
	public Transform target;
	public Transform enemy;
	public Transform launchPoint;
	public GameObject slashEffect;
	public float waitBetweenShots;
	private float shotCounter;
	public float speed = 2f;
	public float minDistance;
	public float playerRange;
	public AnimationClip rangeAttack;
	public AnimationClip meleeAttack;
	private float range;
	public float attackSpeed;
	
	public Animator anim;
	
	public float moveSpeed;
	public bool moveRight;
	
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	
	private bool atEdge;
	public Transform edgeCheck;
	
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	void Start ()
	{
		shotCounter = waitBetweenShots;
	}
	
	
	void Update ()
	{
		range = Vector2.Distance (transform.position, target.transform.position);

		shotCounter -= Time.deltaTime;
		
		Debug.Log ("Range: " + range);
		
		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));
		
		
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
		
		atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
		
		
		if (range >= 17) {

			anim.SetBool ("SlashEffect", false);

			if (hittingWall || !atEdge)
				moveRight = !moveRight;
			
			if (moveRight) {
				transform.localScale = new Vector3 (-3f, 3f, 3f);
				rigidbody2D.velocity = new Vector2 (moveSpeed, rigidbody2D.velocity.y);
			} else {
				transform.localScale = new Vector3 (3f, 3f, 3f);
				rigidbody2D.velocity = new Vector2 (-moveSpeed, rigidbody2D.velocity.y);
			}
			
			
		} else if (range <= 16.9 && range > 5) {

			//Debug.Log ("Slash Effect has been created");

			anim.SetBool ("SlashEffect", true);
		
			if (shotCounter < 0) {
				Instantiate (slashEffect, launchPoint.position, launchPoint.rotation);
				shotCounter = waitBetweenShots;
			}

			if (target.transform.position.x > enemy.transform.position.x) {
				//Debug.Log ("Right");
				transform.localScale = new Vector3 (-3f, 3f, 3f);
			} else {
				//Debug.Log ("Left");
				transform.localScale = new Vector3 (3f, 3f, 3f); 
			}

		} else if (range < 5 && range > 1) {
			anim.SetBool ("SlashEffect", false);
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			//Debug.Log ("You have been seen!");
			if (target.transform.position.x > enemy.transform.position.x) {
				//Debug.Log ("Right");
				transform.localScale = new Vector3 (-3f, 3f, 3f);
			} else {
				//Debug.Log ("Left");
				transform.localScale = new Vector3 (3f, 3f, 3f); 
			}
		} else if (range <= 1) {
			Debug.Log ("stop");

			rigidbody2D.velocity = new Vector2 (attackSpeed, rigidbody2D.velocity.y);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		//if ( playerRange > minDistance)
		//{
		//Debug.Log("playerRange: " + playerRange);
		
		
		
		//Debug.Log ("end");
		
		//}
		
		
		//else {
		
		//Debug.Log ("Attack in progress!");
		
		
		
		
		//}
		
		
		//if (transform.localScale.x < 0 && target.transform.position.x > transform.position.x && target.transform.position.x < transform.position.x + playerRange) 
		//{
		//Debug.Log ("Attack Right");
		//animation.CrossFade (enemyAttack.name);
		//transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		//if (target.transform.position.x > transform.position.x)
		//{
		//Debug.Log ("Right");
		//transform.localScale = new Vector3 (-3.966459f, 3.966459f, 3.966459f);
		//	}
		//else 
		//{
		//Debug.Log ("Left");
		//transform.localScale = new Vector3 (3.966459f, 3.966459f, 3.966459f);
		//}
		
		
		//}
		//if (transform.localScale.x > 0 && target.transform.position.x < transform.position.x && target.transform.position.x > transform.position.x - playerRange) 
		//{
		//Debug.Log ("Attack Left");
		//animation.CrossFade (enemyAttack.name);
		//transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		//if (target.transform.position.x > transform.position.x)
		//{
		//Debug.Log ("Right");
		//transform.localScale = new Vector3 (-3.966459f, 3.966459f, 3.966459f);
		//}
		//else 
		//{
		//Debug.Log ("Left");
		//transform.localScale = new Vector3 (3.966459f, 3.966459f, 3.966459f);
		//}
		
		//}
		
		anim.SetFloat ("Speed", Mathf.Abs(rigidbody2D.velocity.x));

		
	}
}


