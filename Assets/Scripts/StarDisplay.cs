using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {
	public int starAmount;
	Text starAmountText;

	// Use this for initialization
	void Start ()
	{
		if (starAmount == 0) {
			Debug.LogError("Please set the star start amount.");
		}
		starAmountText = this.GetComponent<Text>();
		UpdateStars();
	}
	
	// Update is called once per frame

	public void AddStars (int amount)
	{
		starAmount += amount; 
		UpdateStars();
	}

	public void UseStars (int amount)
	{
		starAmount -= amount;
		UpdateStars();
	}

	void UpdateStars(){
		starAmountText.text = GetStarAmount().ToString();
	}

	public int GetStarAmount ()
	{
		return starAmount;
	}

}
