using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	public int playerCoins =1;
	LvManager lvManager;

	// I think I should make a WorldValue controller;
	void OnTriggerEnter2D (Collider2D collider)
	{
		Destroy (collider.gameObject);
		if (collider.gameObject.GetComponent<Attacker> ()) {
			playerCoins -= 1;
			if (playerCoins <= 0) {
				lvManager = GetComponent<LvManager>();
				lvManager.LvLoader("03b Lose");
			}
		}
	}
}
