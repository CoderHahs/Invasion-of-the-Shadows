using UnityEngine;
using System.Collections;

public class COmpletionWallLevel7 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (FindObjectOfType<VIkingAI> ()) {
			return;
		}
		
		Destroy (gameObject);
		
	} 
}
