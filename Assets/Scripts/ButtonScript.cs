using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	bool isSelected = false;
	Text text;
	ButtonScript[] buttonArray;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = Color.black;
		buttonArray = GameObject.FindObjectsOfType<ButtonScript>();// Store every button in an array;
		SetStarCostText (0f);
	}

	void SetStarCostText (float alpha)
	{
		text = this.GetComponentInChildren<Text> ();
		if (text) {
			Color textColor = text.color;
			textColor.a = alpha;
			text.color = textColor;
		} else {
			Debug.LogError(name+" can`t find any text in child transform.");
		}
	}

	void OnMouseOver(){
		GetComponent<SpriteRenderer>().color = Color.white; 
		SetStarCostText(1f);
		text.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}

	//It is a useful way to let button be unique;
	void OnMouseDown ()
	{
		isSelected = true;
		foreach (ButtonScript thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
			thisButton.GetComponent<ButtonScript>().SetStarCostText(0f);
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
			
	}

	void OnMouseExit ()
	{
		if (isSelected == false) {
			GetComponent<SpriteRenderer> ().color = Color.black;
			SetStarCostText(0f);
		}
	}
}
