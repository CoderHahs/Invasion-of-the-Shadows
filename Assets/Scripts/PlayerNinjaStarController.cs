using UnityEngine;
using System.Collections;

public class PlayerNinjaStarController : MonoBehaviour {
	
	public float speed;
	
	public PlayerController player;

	public float rotationSpeed;

	
	
	
	
	
	
	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<PlayerController> ();
		
		if (player.transform.localScale.x > 0) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else {
			speed = speed;
			rotationSpeed = rotationSpeed;
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
		rigidbody2D.angularVelocity = rotationSpeed;
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		
		Destroy (gameObject);
	}
}
