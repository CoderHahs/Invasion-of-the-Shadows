using UnityEngine;
using System.Collections;

public class CompletionWallLevel4 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (FindObjectOfType<HeadNinjaScript> ()) {
			return;
		}
		
		Destroy (gameObject);
		
	} 
}
