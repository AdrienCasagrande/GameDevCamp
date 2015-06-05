using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int spawnTime = 1;
	public float damage = 1.0f;

	private float endOfSpawn;
	
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce (transform.up * 500);
		Destroy(gameObject, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
