using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	//public int startLives;
	private int lifeCounter;

	private Text theText;

	public GameObject gameOver;

	public PlayerController player;

	public string mainMenu;
	public float waitTime;

	// Use this for initialization
	void Start () {
		theText = GetComponent <Text> ();

		lifeCounter = PlayerPrefs.GetInt ("PlayerCurrentLives");

		player = FindObjectOfType <PlayerController> ();


	
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter < 0) {
			gameOver.SetActive(true);
			player.gameObject.SetActive(false);
		}

		theText.text = "x " + lifeCounter;

		if (gameOver.activeSelf) {
			waitTime -= Time.deltaTime;
		}
		
		if (waitTime < 0) {
			Application.LoadLevel(mainMenu);
		}
	}

	public void GiveLife ()
	{
		lifeCounter ++;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}

	public void TakeLife() 
	{
		lifeCounter--;
		PlayerPrefs.SetInt ("PlayerCurrentLives",lifeCounter);
	}

}
