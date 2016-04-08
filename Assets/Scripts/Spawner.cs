using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] attackerList;


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach(GameObject thisAttacker in attackerList){
			if(IsTimeToSpwan(thisAttacker)){
				Spawn(thisAttacker);
			}
		}
	}

	void Spawn (GameObject attacker)
	{
		GameObject newAttacker = Instantiate(attacker,this.transform.position,Quaternion.identity) as GameObject;
		newAttacker.transform.parent = this.transform;
	}

	bool IsTimeToSpwan (GameObject attackerGameObject)
	{
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnPerSecond = 1 / meanSpawnDelay;
		float threshold = spawnPerSecond * Time.deltaTime/5;

		if (meanSpawnDelay < Time.deltaTime) {
			Debug.LogError ("Spawn rate is capped by frame rate");
			return false;
		} 

		if (Random.value < threshold) {
			return true; 	
		} else {
			return false;
		}
	}
}
