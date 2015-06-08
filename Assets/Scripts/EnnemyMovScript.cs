using UnityEngine;
using System.Collections;

public class EnnemyMovScript : MonoBehaviour {

	public GameObject propulsor;
	public float thrustFreq = 1.0f;
	public float thrustDuration = 0.5f;

	private float nextThrust;

	private Transform target;
	private float angle;

	// Use this for initialization
	void Start () {
		nextThrust = Time.time;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
	}

	void FixedUpdate() {
		if (Time.time >= nextThrust) {
			if (Time.time >= nextThrust + thrustDuration) {
				nextThrust = Time.time + thrustFreq;
			}
			propulsor.GetComponent<PrimaryPropulsorScript> ().thrust (1);	
		}
	}
}
