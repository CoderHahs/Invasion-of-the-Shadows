using UnityEngine;
using System.Collections;

public class ActivateTextAt : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	public TextboxManager theTextBox;

	public bool destroyWhenActivated;





	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<TextboxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			theTextBox.ReloadScript(theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();

			if(destroyWhenActivated)
			{
				Destroy (gameObject);
			}

		}

	}
}
