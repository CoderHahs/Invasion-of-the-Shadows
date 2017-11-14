using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	
	private bool playerInZone;

	public AudioSource sound;
	
	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.W) && playerInZone)
		{
			Destroy (gameObject);
			sound.Play();
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player") {
			playerInZone = true;

		}
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "Player") {
			playerInZone = false;
		}
	}
	
	
}

