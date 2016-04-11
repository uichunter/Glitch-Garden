using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;

    GameObject defenderParents;

	// Use this for initialization
	void Start ()
	{
		GetDefendersFolder();
		myCamera = Camera.main;
		if (myCamera == null) {
			Debug.LogError("Dont know how to create a camera with script.");
		}
	}

	void GetDefendersFolder ()
	{
		defenderParents = GameObject.Find ("Defenders");
		if (defenderParents == null) {
			defenderParents = new GameObject("Defenders");
		} 
	}

	void OnMouseDown ()
	{
		if (isCanSpwan ()) {
			SpwanDefenders ();
		} else {
			Debug.LogError(ButtonScript.selectedDefender +" is over star-cost;");
		}
	}

	bool isCanSpwan ()
	{
		StarDisplay starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		int selectedDefenderCost = ButtonScript.selectedDefender.GetComponent<Defender>().starCost;
		if (starDisplay.GetStarAmount()>=selectedDefenderCost) {
			return true;
		} else {
			return false;
		}
	}

	void SpwanDefenders ()
	{
		Vector2 rawPos = GetGamePosition ();
		Vector2 realPos = GetSnapPos (rawPos);
		GameObject newDefender = Instantiate (ButtonScript.selectedDefender, realPos, Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParents.transform;
		Defender defender = newDefender.GetComponent<Defender> ();
		defender.useStars ();
	}

	Vector2 GetSnapPos (Vector2 rawPos)
	{
		float tempX = Mathf.RoundToInt(rawPos.x);
		float tempY = Mathf.RoundToInt(rawPos.y);
		return new Vector2(tempX,tempY);
	}

	Vector2 GetGamePosition ()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3(mouseX,mouseY,distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

		return worldPos;
	}

}
