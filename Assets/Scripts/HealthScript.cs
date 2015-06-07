using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public float hp = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		BulletScript bullet = collider.gameObject.GetComponent<BulletScript> ();
		if (bullet != null) {
			takeDamage(bullet.damage);
			Destroy(bullet.gameObject);
		}
	}

	void OnCollisionEnter2D() {
		takeDamage (5);
	}

	void takeDamage(float damage) {
		hp -= damage;
		if (hp <= 0) {
			SFXScript.instance.explode(transform.position);
			Destroy(gameObject);
		}
	}
}
