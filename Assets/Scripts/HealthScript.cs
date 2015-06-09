using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public float hp      = 10.0f;
	public int scoreValue = 10;
	public bool isPlayer = false;
	
	void OnTriggerEnter2D(Collider2D collider) {
		BulletScript bullet = collider.gameObject.GetComponent<BulletScript> ();
		if (bullet != null) {
			hp -= bullet.damage;
			Destroy(bullet.gameObject);
			if (hp <= 0) {
				SFXScript.instance.explode(transform.position);
				if (isPlayer) {
					gameObject.GetComponent<GameOverScript>().GameOver();
				} else {
					ScoreScript.instance.addToScore(scoreValue);
				}
				Destroy(gameObject);
			}
		}
	}
}