using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {
	public int starCost;
	
	StarDisplay starDisplay;

	void Start(){
		
	}

	public void addStars (int amount)
	{
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		starDisplay.AddStars(amount);
	}

	public void useStars ()
	{
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		starDisplay.UseStars(starCost);
	}
}
