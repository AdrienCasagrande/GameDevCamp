using UnityEngine;
using System.Collections;

public class RetroPropulsorScript : MonoBehaviour {

	public int thrustPower = 2;

	private float force = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void thrust(float intensity) {
		force = intensity * thrustPower;
		transform.parent.GetComponent<Rigidbody2D>().AddForce (transform.parent.GetComponent<Transform>().up * force);
		SFXScript.instance.burst(transform.position);
		GetComponent<AudioSource>().Play();
	}
}
