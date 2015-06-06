using UnityEngine;
using System.Collections;

public class PlayerMovScript : MonoBehaviour {

	public int thrustPower = 2;
	public int rotationSpeed = 2;

	private float force = 0;
	private float rotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		force = Input.GetAxis ("Vertical") * thrustPower;
		rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		Vector3 myRot = transform.rotation.eulerAngles;
		myRot.z = -rotation;
		transform.Rotate (myRot * Time.deltaTime * 100);
	}

	void FixedUpdate() {
		GetComponent<Rigidbody2D>().AddForce (transform.up * force);
	}
}
