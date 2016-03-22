using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
	//[Range(-1f,2f)] we dont need this anymore;
	private float currentSpeed;
	private GameObject currentTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left*currentSpeed*Time.deltaTime);
	}

	void OnTriggerEnter2D ()
	{
		Debug.Log("Trigger collide.");
	}

	void SetWalkSpeed (float speed)
	{
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget (float damage)
	{
		if (currentTarget) {
			Health targetHealth = currentTarget.GetComponent<Health> ();
			if (targetHealth) {
				targetHealth.DealDamage(damage);
			}
		}
	}

	public void Attack (GameObject obj)
	{
		currentTarget = obj;
	}
}
