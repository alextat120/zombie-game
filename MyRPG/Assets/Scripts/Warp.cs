using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {
	public Transform target;	//target is where the exit will lead to

	/*
	 * Called when another object enters the trigger collider for this object.
	 */
	void OnTriggerEnter2D(Collider2D other){ //other is the Collider2D that collided with this exit/warp point
		other.gameObject.transform.position = target.position;
		if (other.gameObject.name == "Player") {
			Camera.main.transform.position = target.position;
		}
	}

}
