using UnityEngine;
using System.Collections;

public class CompletionWallLevel3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (FindObjectOfType<PharoahAI> ()) {
			return;
		}

		Destroy (gameObject);
			
	}
}
