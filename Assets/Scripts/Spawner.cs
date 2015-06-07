using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		// Invoke("Spawn", spawnTime);
	}

	GameObject Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		GameObject clone = Instantiate(enemies[enemyIndex], transform.position, transform.rotation) as GameObject;
		clone.GetComponent<Rigidbody2D>().AddForce (transform.right * 1000);
		return clone;
	}
}