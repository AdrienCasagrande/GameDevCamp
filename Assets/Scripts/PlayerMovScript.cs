using UnityEngine;
using System.Collections;

public class PlayerMovScript : MonoBehaviour {

	public GameObject primaryPropulsor;
	public GameObject retroPropulsor;
	public int rotationSpeed = 2;
	
	private float rotation;
	private float verticalIntensity = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		verticalIntensity = Input.GetAxis("Vertical");
		rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		Vector3 myRot = transform.rotation.eulerAngles;
		myRot.z = -rotation;
		transform.Rotate (myRot * Time.deltaTime * 100);
	}

	void FixedUpdate() {
		if (verticalIntensity > 0) {
			primaryPropulsor.GetComponent<PrimaryPropulsorScript>().thrust(verticalIntensity);
		} else if (verticalIntensity < 0) {
			retroPropulsor.GetComponent<RetroPropulsorScript>().thrust(verticalIntensity);
		}
	}
}
