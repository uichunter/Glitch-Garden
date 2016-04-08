using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	bool isSelected = false;
	ButtonScript[] buttonArray;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = Color.black;
		buttonArray = GameObject.FindObjectsOfType<ButtonScript>();// Store every button in an array;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		GetComponent<SpriteRenderer>().color = Color.white; 
		selectedDefender = defenderPrefab;
	}

	//It is a useful way to let button be unique;
	void OnMouseDown ()
	{
		isSelected = true;
		foreach (ButtonScript thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
			
	}

	void OnMouseExit ()
	{
		if (isSelected == false) {
			GetComponent<SpriteRenderer> ().color = Color.black;
		}
	}
}
