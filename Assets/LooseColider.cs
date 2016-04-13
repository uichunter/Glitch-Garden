using UnityEngine;
using System.Collections;

public class LooseColider : MonoBehaviour {

	public int playerCoins;
	LvManager lvManager;

	// Use this for initialization
	void Start ()
	{
		playerCoins = 3;

		lvManager = GameObject.FindObjectOfType<LvManager> ();
		if (lvManager == null) {
			Debug.LogError(name+" can`t find any Lv manager.");
		}
	}


	void OnTriggerEnter2D (Collider2D collider)
	{
		Destroy (collider.gameObject);
		if (collider.gameObject.GetComponent<Attacker> ()) {
			playerCoins -= 1;
			if (playerCoins <= 0) {
				lvManager.LvLoader("03b Lose");
			}
		}

	}
}
