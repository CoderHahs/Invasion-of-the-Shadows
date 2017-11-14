using UnityEngine;
using System.Collections;

public class MVHealthManager : MonoBehaviour {

	public int enemyHealth;
	
	public GameObject deathEffect;
	
	public int pointsToAdd;

	public GameObject bossPrefab;

	public float minSize;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (enemyHealth <= 0) {
			Instantiate(deathEffect, transform.position, transform.rotation);

			ScoreManager.AddPoints(pointsToAdd);

			if(transform.localScale.y > minSize)
			{
				GameObject clone1 = Instantiate(bossPrefab, new Vector3 (transform.position.x + 2f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
				GameObject clone2 = Instantiate(bossPrefab, new Vector3 (transform.position.x - 2f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
			
				clone1.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z);
				clone1.GetComponent<MVHealthManager>().enemyHealth = 150;
				clone2.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z);
				clone2.GetComponent<MVHealthManager>().enemyHealth = 150;
			
			}


			Destroy (gameObject);


			
		}


		
	}
	
	public void giveDamage (int damageToGive)
	{
		enemyHealth -= damageToGive;
		audio.Play ();
		gameObject.GetComponent<Animation>().Play ("Player_RedFlash");
		
	}
	
	
}