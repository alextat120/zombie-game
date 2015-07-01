using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject toSpawn;
	public float delaySeconds;
	public float rateSeconds;
	public LevelControl controller;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnObject", delaySeconds, rateSeconds);
	}
	void SpawnObject(){
		GameObject clone;
			clone=Instantiate (toSpawn, transform.position, transform.rotation) as GameObject;
		PlayerStats cloneStats = clone.GetComponent<PlayerStats> ();
		controller.addZombies (1);
		cloneStats.maxHealth = controller.getZombieHealth ();
		cloneStats.health = controller.getZombieHealth ();
		clone.GetComponent<EnemyMovement> ().speed = controller.getZombieSpeed ();
	}


}
