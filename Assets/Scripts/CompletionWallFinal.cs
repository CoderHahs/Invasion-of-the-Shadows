using UnityEngine;
using System.Collections;

public class CompletionWallFinal : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (FindObjectOfType<MainVillainAI> ()) {
			return;
		}
		
		Destroy (gameObject);
		
	}
}
