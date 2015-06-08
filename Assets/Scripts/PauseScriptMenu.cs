using UnityEngine;
using System.Collections;

public class PauseScriptMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {

		//GameObject GameState = FindObjectOfType (PauseScript);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Resume() {
		//int PreviousScene = PlayerPrefs.GetInt ("GameResume");
		//Application.LoadLevel (PreviousScene);
	}

	public void Quit() {
		Application.LoadLevel ("Menu 3D");
	}
}
