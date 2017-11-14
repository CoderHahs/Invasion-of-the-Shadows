using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextboxManagerLevel1 : MonoBehaviour {

	public GameObject textBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	private bool isTyping = false;
	private bool cancelTyping = false;

	public float typeSpeed;

	void Start () {

		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));
		}

		if (endAtLine == 0)
		{
			endAtLine = textLines.Length - 1;
		}

	}

	void Update ()
	{
		//theText.text = textLines [currentLine];
		StartCoroutine(TextScroll(textLines[currentLine]));

		if (Input.GetKeyDown (KeyCode.Return)) {



				currentLine += 1;
			

		 	 if (isTyping && !cancelTyping)
			{
				cancelTyping = true;
			}


		}
	}

	private IEnumerator TextScroll(string lineOfText)
	{
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;
		while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1)) {
			theText.text += lineOfText[letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}
		theText.text = lineOfText;

	}


}
