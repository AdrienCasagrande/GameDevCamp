﻿using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	void Start() {
	}

	void Update () {
	}

	public void GameOver() {
		//Application.LoadLevel ("GameOver");
		FadeLevel.LoadLevel ("GameOVer", 1, 1, Color.black);
	}
}