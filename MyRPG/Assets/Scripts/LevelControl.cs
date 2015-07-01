using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {
	private int numZombies;
	private int level;
	private int zombieHealth;
	private float zombieSpeed;
	private int zombiesToAdd=10;
	private int zombiesInLevel=10;
	// Use this for initialization
	void Start () {
		numZombies = 0;
		zombieHealth = 10;
		zombieSpeed = .5f;
	}

	public void addZombies(int x){
		numZombies += x;
	}
	public int getLevel(){
		return level;
	}
	public int getZombieHealth(){
		return zombieHealth;
	}
	public int getNumZombies(){
		return numZombies;
	}
	public float getZombieSpeed(){
		return zombieSpeed;
	}
	void Update(){
		if (numZombies > zombiesInLevel) {
			zombiesInLevel+=zombiesToAdd;
			numZombies=0;
			zombiesToAdd=zombiesToAdd+(int)(zombiesToAdd*.4);
			zombieHealth=zombieHealth+3;
			level++;
			Debug.Log ("Level is: " + level);
			Debug.Log("Zombie Health: " + zombieHealth);
			Debug.Log ("Number of zombies to spawn until next lvl: " + zombiesInLevel);
		}
	}
}
