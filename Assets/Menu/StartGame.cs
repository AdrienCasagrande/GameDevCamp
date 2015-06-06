using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public void GameStart()
	{
		Application.LoadLevel ("FirstScene");
		//Application.loadedLevel("FirstScene");
	}
}
