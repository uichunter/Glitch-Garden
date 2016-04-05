using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;

	// Use this for initialization
	void Start ()
	{
		myCamera = Camera.main;
		if (myCamera == null) {
			Debug.LogError("Dont know how to create a camera with script.");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown ()
	{
		Debug.Log("World position: "+Input.mousePosition);
		Debug.Log(GetGamePosition());
		Debug.Log(GetSnapPos(GetGamePosition()));
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
