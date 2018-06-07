using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;
	public int currentDamage;
	public GameObject damageBurst;

	private PlayerStats thePS;
	public Text damageInfo;
	public float timeToHide = 2.0f;

	// Use this for initialization
	void Start () {
		thePS = FindObjectOfType<PlayerStats> ();
		damageInfo = GameObject.Find ("DamageInfo").GetComponent<Text> ();
		damageInfo.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (damageInfo.enabled) {
			timeToHide -= Time.deltaTime;
			if (timeToHide < 0.0f) {
				timeToHide = 2.0f;
				damageInfo.enabled = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			//Destroy (other.gameObject); 
			currentDamage = damageToGive + thePS.currentAttack; 
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
			Instantiate (damageBurst, GameObject.Find("swing big").transform.position, GameObject.Find("swing big").transform.rotation);
			damageInfo.enabled = true;
			damageInfo.text = "-" + currentDamage.ToString ();
			timeToHide = 2.0f;
	
		}
	}
}
