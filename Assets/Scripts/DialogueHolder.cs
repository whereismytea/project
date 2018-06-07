using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private Dialogue dMan;
	private Button dbutton;
	public string[] dialogueLines;
	// Use this for initialization
	void Start () {
		dbutton = GameObject.Find ("dialogueButton").GetComponent<Button> ();

		dMan = FindObjectOfType<Dialogue> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			dbutton.onClick.AddListener (() => {
				if (!dMan.dialogueActive) {
					dMan.dialogLines = dialogueLines;
					dMan.currentLine = -1;
					dMan.ShowDialogue ();
				}
			});
	}
  }

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			dbutton.onClick.RemoveAllListeners ();
		}
	}

}
