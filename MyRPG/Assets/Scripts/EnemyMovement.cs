using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	Rigidbody2D rbody;
	//Transform rbody;
	Animator anim;
	public float speed;
	Vector3 movement_vect;
	bool speedDecreased=false;
	float speedMod=1;
	float totalTravel=0;
	 Transform follow;
	private PlayerStats stats;
	// Use this for initialization
	void Start () {
		movement_vect = new Vector3 (0,0);
		rbody = GetComponent<Rigidbody2D>();
		stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		follow = GameObject.FindGameObjectWithTag ("Player").transform;
		//rbody = GetComponent<Transform> ();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Mathf.Abs (follow.position.x - rbody.position.x) < .3 )&& (Mathf.Abs (follow.position.y - rbody.position.y) < .3)) {
			anim.SetBool ("isWalking",false);
			stats.ChangeHealth(-2);
			movement_vect.x=0;
			movement_vect.y=0;
			
		}
		/*if (speedDecreased==false&&totalTravel >= 2000) {
			speed*=.5f;
			speedDecreased=true;
		}*/

		else if (Mathf.Abs (follow.position.x - rbody.position.x) > .2) {
			if (follow.position.x > rbody.position.x) {
				movement_vect.x=1;
				movement_vect.y=0;
				/*anim.SetBool("isWalking",true);
				anim.SetFloat ("input_x",1);
				anim.SetFloat ("input_y",0);*/
			}
			else if (follow.position.x < rbody.position.x) {
				movement_vect.x=-1;
				movement_vect.y=0;
				/*anim.SetBool("isWalking",true);
				anim.SetFloat ("input_x",-1);
				anim.SetFloat ("input_y",0);*/
			}
			anim.SetBool("isWalking",true);
		}
		else if (Mathf.Abs (follow.position.y - rbody.position.y) > .2) {
		 	if (follow.position.y > rbody.position.y) {
				movement_vect.x=0;
				movement_vect.y=1;
			/*anim.SetBool("isWalking",true);
			anim.SetFloat ("input_y",1);
			anim.SetFloat ("input_x",0);*/
			}
			else if (follow.position.y < rbody.position.y) {
				movement_vect.y=-1;
				movement_vect.x=0;
			/*anim.SetBool("isWalking",true);
			anim.SetFloat ("input_y",-1);
			anim.SetFloat ("input_x",0);*/
			}
			anim.SetBool ("isWalking",true);
		}

		/*movement_vect = new Vector3 (Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0);
		if(movement_vect!=Vector3.zero){
			anim.SetBool("isWalking",true);
			anim.SetFloat ("input_x",movement_vect.x);
			anim.SetFloat ("input_y",movement_vect.y);
		}*/

		//totalTravel += (Mathf.Abs (speedMod * movement_vect.x) + Mathf.Abs (speedMod * movement_vect.y));

			//rbody.position.x = rbody.position.x + movement_vect.x;
		//rbody.position.y = rbody.position.y + movement_vect.y;
		//rbody.MovePosition (rbody.position +movement_vect* Time.deltaTime);
	}
	void FixedUpdate(){
		if (anim.GetBool ("isWalking") == true) {
			anim.SetFloat("input_x",movement_vect.x);
			anim.SetFloat("input_y",movement_vect.y);
			rbody.velocity=movement_vect*speed;
			//rbody.position = new Vector3 (rbody.position.x + (anim.GetFloat ("input_x") * speed), rbody.position.y + (anim.GetFloat ("input_y") * speed));//rbody.position + (speedMod*movement_vect * Time.deltaTime);//new Vector3(movement_vect.x*Time.deltaTime,movement_vect.y*Time.deltaTime,0);
		}
	}
}