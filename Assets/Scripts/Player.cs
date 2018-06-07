using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleInputNamespace;

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
	private Object es;
	public Dpad dpad;
	public float xAxis = 0.0f;
	public float yAxis = 0.0f;

	// Use this for initialization
	void Start () {
		es = GameObject.Find ("EventSystem");
		dpad = GameObject.Find ("DpadOnePiece").GetComponent<Dpad> ();
		anim = GetComponent<Animator> (); //обращение к аниматору
		myRigidbody = GetComponent<Rigidbody2D> ();
		sfxMan = FindObjectOfType<SFXManager> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else	{
			Destroy (gameObject);	
		}

		if (es) {
			DontDestroyOnLoad (es);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (dpad) {
			xAxis = dpad.xAxis.value;
			yAxis = dpad.yAxis.value;
		} else {
			xAxis = 0.0f;
			yAxis = 0.0f;
		}

		playerMoving = false;

		if (!attacking) {
			if (xAxis > 0.5f || xAxis < -0.5f) {
				myRigidbody.velocity = new Vector2 (xAxis * moveSpeed, myRigidbody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2 (xAxis, 0f);
			}
			if (yAxis > 0.5f || yAxis < -0.5f) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, yAxis * moveSpeed);
				playerMoving = true;
				lastMove = new Vector2 (0f,yAxis);
			}
			
			if (xAxis < 0.5f && xAxis > -0.5f) {
				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
			}

			if (yAxis < 0.5f && yAxis > -0.5f) {
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

		anim.SetFloat ("MoveX", xAxis);
		anim.SetFloat ("MoveY", yAxis);
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}

	public void Atack(){
		if (!attacking) {
				attackTimeCounter = attackTime;
				attacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);

				sfxMan.playerAttack.Play ();
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
	}
}
