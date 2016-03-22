using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float hp;

	public float currentHp;

	// Use this for initialization
	void Start () {
		currentHp = hp;
	}

	public void DealDamage (float damage)
	{
		currentHp -= damage;
		if (currentHp <= 0) {
			DestroyObject();
		}
	}

	public void DestroyObject ()
	{
		Destroy(gameObject);
	}
}
