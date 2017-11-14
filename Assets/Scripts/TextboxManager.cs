using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;
	public GameObject guide;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;

	public int endAtLine;

	public PlayerController player;
	public bool isActive;

	private bool isTyping = false;
	private  bool cancelTyping = false;

	public float typeSpeed;

	public bool stopPlayerMovement;


	
	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController>();
		
		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));
		}

		if (endAtLine == 0) {

			endAtLine = textLines.Length - 1;

		}

		if (isActive) {
			EnableTextBox();
		}
		else
		{
			DisableTextBox();
		}
		
	}
	
	// Update is called once per frame
	void Update () {


	
		//theText.text = textLines [currentLine];

		//StartCoroutine(TextScroll(textLines[currentLine]));

		if (!isActive) {
			return;
		}

		if (Input.GetKeyDown (KeyCode.Return)) {


			if(!isTyping)
			{
				currentLine += 1;


				if(currentLine > endAtLine)
				{
					DisableTextBox();
				}
				else
				{
					StartCoroutine(TextScroll(textLines[currentLine]));
				}

			}
			else if(isTyping && !cancelTyping)
			{
				cancelTyping = true;
			}



		}

	}

	public void EnableTextBox()
	{
		textBox.SetActive (true);
		isActive = true;
		//StartCoroutine(TextScroll(textLines[currentLine]));
		if (stopPlayerMovement) {
			//StartCoroutine(TextScroll(textLines[currentLine]));
			player.canMove = false;
		}

		StartCoroutine(TextScroll(textLines[currentLine]));


	}

	public void DisableTextBox()
	{
		textBox.SetActive (false);
		isActive = false;
		player.canMove = true;


	}

	public void ReloadScript (TextAsset theText)
	{
		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));
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
		isTyping = false;
		cancelTyping = false;
	}


}
