using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	private SFXManager sfxMan;
	// Use this for initialization
	void Start () {

		playerCurrentHealth = playerMaxHealth;
		sfxMan = FindObjectOfType<SFXManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerCurrentHealth <= 0) {

			sfxMan.playerDead.Play ();
			playerCurrentHealth = playerMaxHealth;
			Destroy (GameObject.Find ("BGM"));
			SceneManager.LoadScene ("menu");


		}
	}

	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;

		sfxMan.playerHurt.Play ();

	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}
}
