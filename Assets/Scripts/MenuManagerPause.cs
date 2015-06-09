using UnityEngine;
using System.Collections;

public class MenuManagerPause : MonoBehaviour {
	public GameObject menu;


	public void resume() {
		menu.SetActive (false);
		Time.timeScale = 1;
	}
	
	public void Quit() {
		menu.SetActive (false);
		Time.timeScale = 1;
		Application.LoadLevel ("Menu 3D");
	}
}
