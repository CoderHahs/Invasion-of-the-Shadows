using UnityEngine;
using System.Collections;

public class CompletionWallLevel6 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (FindObjectOfType<EnemyAI> ()) {
			return;
		}
		
		Destroy (gameObject);
		
	} 
}
