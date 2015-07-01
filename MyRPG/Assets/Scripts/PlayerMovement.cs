using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rigid_body;
	Animator anim;
	public float speed;
	Vector2 movement_vect;
	bool speedDecreased=false;
	float speedMod=1;
	 float totalTravel=0;
	Weapon gun;
	// Use this for initialization
	void Start () {
		rigid_body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		gun = GetComponent<Weapon> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("tab")){
			Debug.Log("Shooting");
			gun.Shoot();
			/*GameObject clone;
			clone = Instantiate (toFire,transform.position,transform.rotation) as GameObject;
			MoveScript cloneMove = clone.GetComponent<MoveScript>();
			cloneMove.direction=rigid_body.velocity;
			Destroy (clone,1f);*/
		}
		//Debug.Log ("total travel: " + totalTravel);
		if (speedDecreased==false&&totalTravel >= 2000) {
			speed*=.5f;
			speedDecreased=true;
		}
		if(Input.GetKeyDown("space")){
			Debug.Log ("super speed");
			speedMod=speed;
		}
		else if(Input.GetKeyUp("space")){
			Debug.Log("normal speed");
			speedMod=1;
		}

		movement_vect = new Vector2 (Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
		if(movement_vect!=Vector2.zero){
			anim.SetBool("isWalking",true);
			anim.SetFloat ("input_x",movement_vect.x);
			anim.SetFloat ("input_y",movement_vect.y);
		}
		else{

			anim.SetBool("isWalking",false);
		}
		totalTravel += (Mathf.Abs (speedMod * movement_vect.x) + Mathf.Abs (speedMod * movement_vect.y));

}
	void FixedUpdate(){
		rigid_body.velocity = speedMod*movement_vect;
	}
}