using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float spawnTime = 1.0f;
	public float damage = 1.0f;
	public float fireRate = 0.5f;
	public AudioClip sound;

	private float endOfSpawn;
	
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce (transform.up * 500);
		Destroy(gameObject, spawnTime);
		SFXScript.instance.playSound (sound);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
