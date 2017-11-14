using UnityEngine;
using System.Collections;

public class GuideAI : MonoBehaviour {

	public Transform target;
	public Transform enemy;

	public float minDistance;
	public float playerRange;

	private float range;

	
	public Animator anim;
	

	
	
	void Update ()
	{
		range = Vector2.Distance (transform.position, target.transform.position);
		
		Debug.Log ("Range: " + range);
		
		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));
		
		

		
		if (range >= 8) {

			anim.SetBool("Jaw", false);

			
		} else if (range < 7) {

			anim.SetBool ("Jaw", true);

			if (target.transform.position.x > enemy.transform.position.x) {
				//Debug.Log ("Right");
				transform.localScale = new Vector3 (-3f, 3f, 3f);
			} else {
				//Debug.Log ("Left");
				transform.localScale = new Vector3 (3f, 3f, 3f); 
			}
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
		
	
		
	}
}
