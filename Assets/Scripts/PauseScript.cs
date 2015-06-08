using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	public bool       CanPause;
	public GameObject UIMenu;

	
	void Start () {
		UIMenu.SetActive (false);
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
				UIMenu.SetActive(true);
				Time.timeScale = 0;
			} 
			else
			{
				UIMenu.SetActive(false);
				Time.timeScale = 1;
			}
		}
	}
}
