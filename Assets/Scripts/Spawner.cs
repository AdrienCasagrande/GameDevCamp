using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
	public float forceMax = 1;
	public float forceMin = 5;
	private float angle;
	Vector2 direction;

	void Start ()
	{
	
	}

	GameObject Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);

		Vector3 target = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 1.0f));
		angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

		GameObject clone = Instantiate(enemies[enemyIndex], transform.position, transform.rotation) as GameObject;

		switch (Random.Range (1,4)) {
			case 1:
				direction = - transform.up;
				break;
			case 2:
				direction = - transform.right;
				break;
			case 3:	
				direction = transform.up;
				break;
			case 4:
				direction = transform.right;
				break;
			default:
				break;
		}
		clone.GetComponent<Rigidbody2D>().AddForce (direction * Random.Range(forceMin, forceMax)/5, ForceMode2D.Impulse);
		return clone;
	}
}