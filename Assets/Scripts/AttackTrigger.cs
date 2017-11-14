using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	public int damageToGive;

	public GameObject enemyDeathEffect;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Enemy"){
			//(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);

			var enemy = other.GetComponent<EnemyPatrol>();
			enemy.knockbackCount = enemy.knockbackLength;
			
			if (other.transform.position.x >= transform.position.x)
				enemy.knockFromRight = true;
			else 
				enemy.knockFromRight = false;
		}

		if (other.tag == "Main Villain") {
			other.GetComponent<MVHealthManager>().giveDamage(damageToGive);
		}
	}
		
}
