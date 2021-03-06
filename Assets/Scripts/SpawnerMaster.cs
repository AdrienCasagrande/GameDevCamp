using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerMaster : MonoBehaviour {

	public Vector3 spawnValues;
	public int hazardCount = 3;
	public float minimum_respawn_safe_distance_;
	public float min_spawner_torque_ = 50.0f;
	public float max_spawner_torque_ = -50.0f;

	public float spawnWait = 1.0f;
	public float nextSpawn;
	public float startWait = 2.0f;
	private bool nextWave = true;
	
	void Start () {
		nextSpawn = Time.time;
		startWait = Time.time + startWait;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= startWait) {
			if (nextWave) {
				SpawnWaves();
				nextWave = false;
			}
		}
	}

	void SpawnWaves ()
	{
			for (int i = 0; i < hazardCount; i++) {
				GameObject spawner = GenerateSpawner();
				Destroy(spawner);
				if (Time.time >= nextSpawn){
					nextSpawn = Time.time + spawnWait;
					
				}
				
			}
	}
	
	int GenerateCornerPositionAndDirection(out Vector3 position, out Vector3 direction, bool force_corner, int corner)
	{
		if (!force_corner) {
			corner = Random.Range(1, 5); //1 = Left, 2 = Top, 3 = Right, 4 = Bottom        
		}
		float x = 0.0f;
		float y = 0.0f;
		float x_dir = 0.0f;
		float y_dir = 0.0f;
		float min_dist_threshold = 0.1f; // This value is to prevent asteroids from having a straight line trajectory in the screen corners; 
		//they should go near the center of the screen        
		switch (corner)
		{
		case 1:
			y = Random.Range(0.0f, 1.0f);
			x_dir = 1.0f;
			y_dir = Random.Range(0.0f, 1.0f);
			while (Mathf.Abs(y - y_dir) < min_dist_threshold) {
				y_dir = Random.Range(0.0f, 1.0f);
			}
			break;
		case 2:
			x = Random.Range(0.0f, 1.0f);
			y = 1.0f;
			
			x_dir = Random.Range(0.0f, 1.0f);
			while (Mathf.Abs(x - x_dir) < min_dist_threshold) {
				x_dir = Random.Range(0.0f, 1.0f);
			}
			
			y_dir = 0.0f;
			break;
		case 3:
			x = 1.0f;
			y = Random.Range(0.0f, 1.0f);
			
			x_dir = 0.0f;
			y_dir = Random.Range(0.0f, 1.0f);
			while (Mathf.Abs(y - y_dir) < min_dist_threshold) {
				y_dir = Random.Range(0.0f, 1.0f);
			}
			break;
		case 4:
			x = Random.Range(0.0f, 1.0f);
			
			x_dir = Random.Range(0.0f, 1.0f);
			while (Mathf.Abs(x - x_dir) < min_dist_threshold) {
				x_dir = Random.Range(0.0f, 1.0f);
			}
			y_dir = 1.0f;
			break;
			
		}
		position = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 0.0f));
		position.z = 0.0f;
		
		direction = Camera.main.ViewportToWorldPoint(new Vector3(x_dir, y_dir, 0.0f)) - position;
		direction.z = 0.0f;
		direction.Normalize();
		return corner;
	}

	bool IsSafeDistance(Vector3 position)
	{
		GameObject player_ship_instance_ = GameObject.Find ("Player");
		if (player_ship_instance_ != null) {
			float distance = (player_ship_instance_.transform.position - position).magnitude;
			return distance > minimum_respawn_safe_distance_;
		}
		return true;
	}

	GameObject GenerateSpawner()
	{
		Vector3 position;
		Vector3 direction;
		int corner = GenerateCornerPositionAndDirection(out position, out direction, false, 0);

		if (!IsSafeDistance(position)) {
			int new_corner = (corner % 4) + 2;
			GenerateCornerPositionAndDirection(out position, out direction, true, new_corner);
		}

		GameObject spawner = GameObject.Instantiate(Resources.Load("Spawner", typeof(GameObject)), position, Quaternion.identity) as GameObject;
		float torque = Random.Range(min_spawner_torque_, max_spawner_torque_);
		spawner.GetComponent<Rigidbody2D>().AddTorque(torque);
		Debug.Log (position);
		spawner.SendMessage("Spawn");
		return spawner;
	}

}
