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

	//private Button dbutton;
	// Use this for initialization
	void Start () {
		//dbutton = GameObject.Find ("skipDialogue").GetComponent<Button> ();

	}
	
	// Update is called once per frame
	void Update () {		
		if (currentLine >= dialogLines.Length) 
		{
			dBox.SetActive (false);
			dialogueActive = false;
			//dbutton.onClick.RemoveAllListeners ();
			currentLine = 0;
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

	public void Skip(){
		Debug.Log("clicked");
		currentLine++;
		dText.text = dialogLines [currentLine];
	}
		
}
