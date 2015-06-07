using UnityEngine;
using System.Collections;

public class EnnemyCannonScript : MonoBehaviour {

	public GameObject ammo;

	private float nextFire;

	// Use this for initialization
	void Start () {
		nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextFire) {
			nextFire = Time.time + ammo.GetComponent<BulletScript>().fireRate;
			GameObject clone = (GameObject) Instantiate(ammo, transform.position, transform.rotation);
			clone.GetComponent<Rigidbody2D>().velocity = transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity;
		}
	}
}
