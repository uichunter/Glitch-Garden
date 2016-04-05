using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile,gun;

	GameObject projectileParents;

	//This sample code used to track any gameobject you need before running. If it not existing, create it;
	void Start ()
	{
		projectileParents = GameObject.Find ("Projectiles");
		if (projectileParents == null) {
			projectileParents = new GameObject("Projectiles");
		}
	}

	void Fire ()
	{
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParents.transform;
		//newProjectile.transform.parent = GameObject.Find("Projectiles").transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
