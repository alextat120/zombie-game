using UnityEngine;
using System.Collections;

public class StatModifier : MonoBehaviour {
	public string stat;	//name of stat to be reduced
	public int statMod;	//modification number 
	PlayerStats myStats;
	public AudioClip sound;
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Player") {
			myStats = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();

			if (stat == "health") {
				AudioSource.PlayClipAtPoint(sound, this.transform.position);
				if (statMod + myStats.health > myStats.maxHealth) {
					myStats.health = myStats.maxHealth;
				} else {
					myStats.health += statMod;
				}
			}
			Destroy (this.gameObject);
		}
	}
}
