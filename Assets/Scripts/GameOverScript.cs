using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	private float hp;
	private bool Lose = false;
	
	public void GameOver() {
		FadeLevel.LoadLevel ("GameOVer", 1, 1, Color.black);
	}
	
	void Update () {
		hp = gameObject.GetComponent<HealthScript>().hp;
		print (hp);
	}
	
	//void OnDestroy(){
	//	if (hp <= 0) {
	//		FadeLevel.LoadLevel ("GameOver", 1, 1, Color.black);
	//	}
	//}
}