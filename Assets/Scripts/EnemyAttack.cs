using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float playerRange;

	public AnimationClip enemyAttack;

	public PlayerController player;

	public GameObject warrior;

	private Animator anim;

	//public Transform launchPoint;



	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));

		if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange) {
			animation.CrossFade (enemyAttack.name);
			SendMessage ("WarriorAttack");
		}
		if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange) {
			animation.CrossFade(enemyAttack.name);
			SendMessage ("WarriorAttack");
		}
	
		anim.SetFloat ("Speed", Mathf.Abs(rigidbody2D.velocity.x));
	
	}



	public void WarriorAttack ()
	{
		Debug.Log ("WarriorAttack");
			
		if (enemyAttack == null) {
			Debug.Log ("We need an animation");
			return;
		}

	}


}
