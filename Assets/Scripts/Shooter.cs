using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile,gun;
	public float shootRange;
	GameObject projectileParents;
	Spawner myLaneSpawner;
	Animator animator;

	//This sample code used to track any gameobject you need before running. If it not existing, create it;
	void Start ()
	{
		projectileParents = GameObject.Find ("Projectiles");
		if (projectileParents == null) {
			projectileParents = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
	}

	void SetMyLaneSpawner ()
	{
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		if (spawnerArray.Length == 0) {
			Debug.LogError("name" + "can`t find any spawner in scene.");
		}

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError(name + "can`t find a spawner in lane.");
	}

	void Update ()
	{
		animator = this.GetComponent<Animator> ();
		if (isAttackerTracked ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	bool isAttackerTracked ()
	{
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		foreach (Transform attacker in myLaneSpawner.transform) {
			if (getAtkToDefDistance (attacker) <= shootRange && getAtkToDefDistance(attacker) >0f) {
				return true;
			}
		}
		return false;
	}

	float getAtkToDefDistance (Transform attacker)
	{
		float distance = attacker.position.x - transform.position.x;
		return distance;
	}

	void Fire ()
	{
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParents.transform;
		//newProjectile.transform.parent = GameObject.Find("Projectiles").transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
