using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerPrefab;
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attackerPrefab) {
			if (isTimeToSpawn (attacker)) {
				Spawn (attacker);
			}
		}
	}

	void Spawn (GameObject attacker)
	{
		if (attacker) {
			GameObject obj = Instantiate (attacker, transform.position, Quaternion.identity);
			obj.transform.parent = transform;
		}
	}

	bool isTimeToSpawn(GameObject attackerGameObject) 
	{
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		return(Random.value < threshold);
	}
}
