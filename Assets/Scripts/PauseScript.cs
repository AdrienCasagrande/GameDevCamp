using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	public bool       CanPause;
	public GameObject PauseMenuUI;
	
	void Start () {
		PauseMenuUI.SetActive (false);
		CanPause = true;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				CanPause = true;
			}
			if (Time.timeScale == 0) {
				CanPause = false;
			}
			if (CanPause) 
			{
				PauseMenuUI.SetActive(true);
				Time.timeScale = 0;
			} 
			else
			{
				PauseMenuUI.SetActive(false);
				Time.timeScale = 1;
			}
		}
	}
}
