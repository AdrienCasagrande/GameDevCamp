using UnityEngine;
using System.Collections;

public class CannonScript : MonoBehaviour {

	public GameObject munition;
	public float fireRate = 0.2f;

	private float nextFire;

	// Use this for initialization
	void Start () {
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time >= nextFire && Input.GetAxis ("Fire1") > 0) {
			nextFire = Time.time + fireRate;
			Instantiate(munition, transform.position, transform.rotation);
		}
	}

}
