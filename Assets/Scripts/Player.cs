using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {
	public float moveSpeed;

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	private Vector2 lastMove;

	private static bool playerExists; // все объекты, прикрепленные к скрипту используют бул

	public string startPoint;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	private SFXManager sfxMan;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); //обращение к аниматору
		myRigidbody = GetComponent<Rigidbody2D> ();
		sfxMan = FindObjectOfType<SFXManager> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 

		else
		{
			Destroy (gameObject);	
		}
			

	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

		if (!attacking) {
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, myRigidbody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
				playerMoving = true;
				lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}
			
			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
			}

			if (Input.GetKeyDown (KeyCode.J)) {
				attackTimeCounter = attackTime;
				attacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);

				sfxMan.playerAttack.Play ();

			}
		}

		if (attackTimeCounter > 0) 
		{
			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0) 
		{
			attacking = false;
			anim.SetBool ("Attack", false);
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}
