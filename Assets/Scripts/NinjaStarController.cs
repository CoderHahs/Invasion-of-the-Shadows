using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {
	
	public float speed;
	
	public NinjaAi enemy;

	public float rotationSpeed;
	
	
	
	
	
	
	// Use this for initialization
	void Start () {

		enemy = FindObjectOfType<NinjaAi> ();
		
		if (enemy.transform.localScale.x > 0) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
			transform.localScale = new Vector3 (3f, 3f, 3f);
		} else {
			speed = speed;
			rotationSpeed = rotationSpeed;
			transform.localScale = new Vector3 (-3f, 3f, 3f);
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

