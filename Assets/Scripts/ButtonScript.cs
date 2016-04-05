using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	public GameObject defenderPrefab;
	private static GameObject selectedDefender;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		GetComponent<SpriteRenderer>().color = Color.white; 
		selectedDefender = defenderPrefab;
	}

	void OnMouseExit ()
	{
		GetComponent<SpriteRenderer>().color = Color.black;
	}
}
