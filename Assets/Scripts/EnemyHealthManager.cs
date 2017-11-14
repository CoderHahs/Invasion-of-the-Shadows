using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;

	public GameObject deathEffect;

	public int pointsToAdd;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (enemyHealth <= 0) {
			Instantiate(deathEffect, transform.position, transform.rotation);
			Destroy (gameObject);
			ScoreManager.AddPoints(pointsToAdd);

		}
	
	}

	public void giveDamage (int damageToGive)
	{
		enemyHealth -= damageToGive;
		audio.Play ();
		gameObject.GetComponent<Animation>().Play ("Player_RedFlash");

	}


}
