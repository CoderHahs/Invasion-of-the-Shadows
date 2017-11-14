using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

		atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);


		if (hittingWall || !atEdge)
			moveRight = !moveRight;
	
		if (moveRight) {
			transform.localScale = new Vector3 (-3.966459f, 3.966459f, 3.966459f);
			rigidbody2D.velocity = new Vector2 (moveSpeed, rigidbody2D.velocity.y);
		} else {
			transform.localScale = new Vector3 (3.966459f, 3.966459f, 3.966459f);
			rigidbody2D.velocity = new Vector2 (-moveSpeed, rigidbody2D.velocity.y);
		}

		if (knockbackCount <= 0) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y);
		} else {
			if (knockFromRight)
				rigidbody2D.velocity = new Vector2 (knockback, 0);
			if (!knockFromRight)
				rigidbody2D.velocity = new Vector2 (-knockback, 0);
			knockbackCount -= Time.deltaTime; 
		}

	}
}
