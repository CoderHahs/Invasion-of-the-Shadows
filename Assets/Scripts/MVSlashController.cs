using UnityEngine;
using System.Collections;

public class MVSlashController : MonoBehaviour {
	
	public float speed;
	
	public MainVillainAI enemy;


	
	
	
	
	
	
	// Use this for initialization
	void Start () {
		enemy = FindObjectOfType<MainVillainAI> ();
		
		
		if (enemy.transform.localScale.x > 0) {
			speed = -speed;
			transform.localScale = new Vector3 (2f, 2f, 2f);
		} else {
			speed = speed;
			transform.localScale = new Vector3 (-2f, 2f, 2f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		Destroy (gameObject);
	}
}
