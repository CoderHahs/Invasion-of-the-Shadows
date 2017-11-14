using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public string howToPlay;

	public string mainMenu;

	public int playerLives;



	public void StartGame ()
	{


		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);

		PlayerPrefs.SetInt ("CurrentScore", 0);

		Application.LoadLevel (startLevel);
	}

	//Actually Credits
	public void HowToPlay()
	{
		Application.LoadLevel (howToPlay);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

	public void TitleMenu ()
	{
		Application.LoadLevel(mainMenu);
	}

}
