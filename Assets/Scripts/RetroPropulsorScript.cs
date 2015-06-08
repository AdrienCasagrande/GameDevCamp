using UnityEngine;
using System.Collections;

public class RetroPropulsorScript : MonoBehaviour {

	public int thrustPower = 2;

	private float force = 0;
	private float nextPlay;
	// Use this for initialization
	void Start () {
		nextPlay = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void thrust(float intensity) {
		force = intensity * thrustPower;
		transform.parent.GetComponent<Rigidbody2D>().AddForce (transform.parent.GetComponent<Transform>().up * force);
		SFXScript.instance.burst(transform.position);
		if (Time.time >= nextPlay) {
			nextPlay = Time.time + 0.9f;
			GetComponent<AudioSource> ().Play ();
		}
	}
}
