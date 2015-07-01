using UnityEngine;
using System.Collections;

public class PauseUI : MonoBehaviour {
	private bool paused=false;
	public GameObject pauseUI;
	// Use this for initialization
	void Start () {
		pauseUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Pause")){
			paused=!paused;
		}
		if (paused) {
			pauseUI.SetActive (true);
			Time.timeScale = 0;
		} else if (!paused) {
			pauseUI.SetActive(false);
			Time.timeScale=1;
		}
	}
}
