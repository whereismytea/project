using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public bool dialogueActive = false;

	public string[] dialogLines;
	public int currentLine = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		if (currentLine >= dialogLines.Length) 
		{
			dBox.SetActive (false);
			dialogueActive = false;

			currentLine = 0;
		}

		if (dialogueActive)
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				currentLine++;
			}
			//dBox.SetActive (false);
			//dialogueActive = false;
			dText.text = dialogLines[currentLine];
		}

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
