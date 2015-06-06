using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	public bool CanPause;
	public GameObject PauseMenuUI;

	// Use this for initialization
	void Start () {
		CanPause = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (CanPause) 
			{
				print ("toto");
				Time.timeScale = 0;
				CanPause = false;
			} else 
			{
				print ("tata");
				Time.timeScale = 1;
				CanPause = true;
			}
		}
	}

	void OnGUI()
	{
		if (!CanPause) {
			if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 - 20, 80, 40), "test")) {
				//PauseMenuUI.GetComponent<PauseMenuUI>().enabled = true;
				//CanPause = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 + 20, 80, 40), "Qui")) {

				Time.timeScale = 1;
				//Application.LoadLevel("Menu 3D");

				//FadeLevel.LoadLevel ("Menu 3D", 1, 1, Color.black);
				//Test du game over
				//FadeLevel.LoadLevel ("GameOver", 1, 1, Color.black);
			}
		}
	}
}
