using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public int maxHealth;
	public int health;
	public int stamina;
	private int myStamina;
	 public PlayerMovement moveScript;
	bool reduce=true;
	// Use this for initialization
	void Start () {
		myStamina = stamina;
		moveScript = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("My stamina is " + stamina);
		if (health <=0 || stamina == 0) {
			if(gameObject.name=="Player"){
			Debug.Log ("DEAD");
			Application.LoadLevel (0);
			}
			else{
				Destroy(this.gameObject);
			}
		}
		if (gameObject.name == "Player") {
			if (reduce == true && stamina <= myStamina / 2) {
				Debug.Log ("Super Speed reduced");
				DecreaseSpeed ();
				reduce = false;
			} 
		} 
	}
	 void DecreaseSpeed(){
		moveScript.speed=moveScript.speed*0.4f;
	}
	public void ChangeHealth(int x){
		health += x;
	}

}