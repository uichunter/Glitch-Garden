using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile,projectileParents,gun;

	void Fire ()
	{
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParents.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
