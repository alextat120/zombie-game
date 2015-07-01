using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour {
	// Use this for initialization
	int health;
	Text h_text;
	PlayerStats player;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats>();//.GetComponent<PlayerStats>();
		h_text = GetComponent<Text> ();

		//h_script = player.GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		h_text.text = ""+player.health;
	}
}
