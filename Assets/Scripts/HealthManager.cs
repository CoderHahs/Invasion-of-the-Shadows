﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;

	public static int playerHealth;

	//Text text;

	public Slider healthBar;

	public bool isDead;

	private LevelManager levelManager;

	private LifeManager lifeSystem;

	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();

		healthBar = GetComponent<Slider> ();

		playerHealth = maxPlayerHealth;
		levelManager = FindObjectOfType<LevelManager> ();
		isDead = false;
		lifeSystem = FindObjectOfType <LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			levelManager.RespawnPlayer();
			lifeSystem.TakeLife();
			isDead = true;
		}

		//text.text = "" + playerHealth;

		healthBar.value = playerHealth;

	}

	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;

	}

	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
	}
}
