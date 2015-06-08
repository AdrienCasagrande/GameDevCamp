using UnityEngine;
using System.Collections;

public class Toto : MonoBehaviour {
	public GameObject test;

	public void resume() {
		test.SetActive (false);
		Time.timeScale = 1;
	}

	public void Quit() {
		test.SetActive (false);
		Time.timeScale = 1;
		Application.LoadLevel ("Menu 3D");
	}
}
