using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public int damage=2;
	public float fireRate = .3f;
	private float coolDown;
	public GameObject toFire;
	private Rigidbody2D player;
	void Start(){
		player = GetComponent<Rigidbody2D> ();
		coolDown = 0f;
	}
	void Update(){
		if (coolDown > 0) {
			coolDown-=Time.deltaTime;
		}
	}
	public bool isCoolDown(){
		return coolDown>0f;
	}
	public void Shoot(){
		if (!isCoolDown()) {
			coolDown=fireRate;
			GameObject clone;
			clone = Instantiate (toFire,player.transform.position,player.transform.rotation) as GameObject;
			MoveScript cloneMove = clone.GetComponent<MoveScript>();
			cloneMove.direction=player.velocity;
			Destroy (clone,1f);
		}
	}
}
