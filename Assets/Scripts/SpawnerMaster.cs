using UnityEngine;
using System.Collections;

public class SpawnerMaster : MonoBehaviour {

	public Garbage garbage;
	public Spawner spawner;
	private GameObject[] spawners;


	public float minimum_respawn_safe_distance_;
	public float min_spawner_torque_ = 50;
	public float max_spawner_torque_ = -50;
	
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GameObject spawner = GenerateSpawner();
		Destroy(spawner);
	}

	int GenerateCornerPositionAndDirection(out Vector3 position, out Vector3 direction, bool force_corner, int corner)
	{
		if (!force_corner)
		{
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
			while (Mathf.Abs(y - y_dir) < min_dist_threshold)
			{
				y_dir = Random.Range(0.0f, 1.0f);
			}
			break;
		case 2:
			x = Random.Range(0.0f, 1.0f);
			y = 1.0f;
			
			x_dir = Random.Range(0.0f, 1.0f);
			while (Mathf.Abs(x - x_dir) < min_dist_threshold)
			{
				x_dir = Random.Range(0.0f, 1.0f);
			}
			
			y_dir = 0.0f;
			break;
		case 3:
			x = 1.0f;
			y = Random.Range(0.0f, 1.0f);
			
			x_dir = 0.0f;
			y_dir = Random.Range(0.0f, 1.0f);
			while (Mathf.Abs(y - y_dir) < min_dist_threshold)
			{
				y_dir = Random.Range(0.0f, 1.0f);
			}
			break;
		case 4:
			x = Random.Range(0.0f, 1.0f);
			
			x_dir = Random.Range(0.0f, 1.0f);
			while (Mathf.Abs(x - x_dir) < min_dist_threshold)
			{
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
		if (player_ship_instance_ != null)
		{
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
		//Checks if the asteroid is gonna be spawned too close to the player
		if (!IsSafeDistance(position))
		{
			int new_corner = (corner % 4) + 2;
			GenerateCornerPositionAndDirection(out position, out direction, true, new_corner);
		}
		
		GameObject spawner = GameObject.Instantiate(Resources.Load("Spawner", typeof(GameObject)), position, Quaternion.identity) as GameObject;
		float asteroid_speed = Random.Range(1, 11);
		//spawner.GetComponent<Rigidbody2D>().velocity = direction * asteroid_speed * Time.deltaTime;
		

		
		float torque = Random.Range(min_spawner_torque_, max_spawner_torque_);
		spawner.GetComponent<Rigidbody2D>().AddTorque(torque);

		spawner.SendMessage("Spawn");
		return spawner;
	}

}
