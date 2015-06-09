using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	void Start() {
	}

	void Update () {
	}

	public void GameOver() {
		FadeLevel.instance.LoadLevel ("GameOVer", 1, 1, Color.black);
	}
}