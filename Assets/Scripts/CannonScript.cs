using UnityEngine;
using System.Collections;

public class CannonScript : MonoBehaviour {

	public GameObject[] munition;

	private float nextFire;
	private int ammoSelect = 0;

	// Use this for initialization
	void Start () {
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Ammo1") > 0) {
			ammoSelect = 0;
		} else if (Input.GetAxis("Ammo2") > 0 && munition.Length > 1) {
			ammoSelect = 1;
		} else if (Input.GetAxis("Ammo3") > 0 && munition.Length > 2) {
			ammoSelect = 2;
		} else if (Input.GetAxis("Ammo4") > 0 && munition.Length > 3) {
			ammoSelect = 3;
		}

		if (Time.time >= nextFire && Input.GetAxis ("Fire1") > 0) {
			nextFire = Time.time + munition[ammoSelect].GetComponent<BulletScript>().fireRate;
			GameObject clone = (GameObject) Instantiate(munition[ammoSelect], transform.position, transform.rotation);
			clone.GetComponent<Rigidbody2D>().velocity = transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity;
		}
	}

}
