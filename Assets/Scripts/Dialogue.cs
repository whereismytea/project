using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public bool dialogueActive;

	public string[] dialogLines;
	public int currentLine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueActive && Input.GetKeyUp(KeyCode.Space))
			
		{
			//dBox.SetActive (false);
			//dialogueActive = false;

			currentLine++;
		}

		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dialogueActive = false;

			currentLine = 0;
		}
			dText.text = dialogLines [currentLine];
		}

	public void ShowBox(string dialogue)
	{
		dialogueActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
	}

	public void ShowDialogue()
	{
		dialogueActive = true;
		dBox.SetActive (true);
	}
}
