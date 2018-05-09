using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;
	private int currentDamage;
	public GameObject damageBurst;

	private PlayerStats thePS;


	// Use this for initialization
	void Start () {
		thePS = FindObjectOfType<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			//Destroy (other.gameObject); 
			currentDamage = damageToGive + thePS.currentAttack; 
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			Instantiate (damageBurst, transform.position, transform.rotation);
		}

	}
}
