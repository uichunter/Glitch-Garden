using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {
	private Animator animator;
	private Attacker atk;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		atk = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defender> ()) {
			return;
		} 

		if (obj.GetComponent<StoneWall> ()) {
			animator.SetTrigger ("Jump Trigger");
		} else {
			atk.Attack(obj);
			animator.SetBool("isAttacking",true);
		}
	}
}
