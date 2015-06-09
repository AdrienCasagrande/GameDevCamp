using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WavesControllerScript : MonoBehaviour {
	
	public GameObject[] ennemies;
	public int[] waveMap;
	public float minimum_respawn_safe_distance_ = 0.1f;
	public float spawnPerSec = 3f;

	private bool canStartWave = true;
	private bool startOfWave = true;
	private float spawnTimer;
	private float nextSpawn;

	private int wavesCount = 0;
	private List<int> nextWave;
	private int maxSpawn;
	private int totalSpawn;
	private int toSpawn;

	private int waveBase = 0;
	private int Ispawn = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < waveMap.Length; i++) {
			maxSpawn += waveMap[i];
		}
		spawnTimer = 1f / spawnPerSec;
		nextSpawn = Time.time;
		prepareNextWave ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreScript.instance.currentWave <= 0) {
			canStartWave = true;
			startOfWave = true;
		}

		if (canStartWave) {
			if (startOfWave) {
				ScoreScript.instance.addToWave(totalSpawn);
				startOfWave = false;
				print(waveBase);
			}

			if (Time.time >= nextSpawn) {
				nextSpawn = Time.time + spawnTimer;
				spawn ();
				// update iterators
				nextWave[Ispawn - waveBase]--;
				toSpawn--;
				if (nextWave[Ispawn - waveBase] <= 0 && toSpawn > 0) {
					Ispawn++;
				}
			}

			// end of wave
			if (toSpawn <= 0) {
				canStartWave = false;
				wavesCount++;
				Ispawn = waveBase;
				prepareNextWave();
			}
		}
	}

	void spawn() {
		Vector3 position;
		Quaternion direction;
		int corner = GenerateCornerPositionAndDirection(out position, out direction, false, 0);
		
		if (!IsSafeDistance(position)) {
			int new_corner = (corner % 4) + 2;
			GenerateCornerPositionAndDirection(out position, out direction, true, new_corner);
		}
		GameObject clone = (GameObject) Instantiate(ennemies[Ispawn], position, direction);
		clone.GetComponent<Rigidbody2D>().AddForce (transform.up * Random.Range(1, 5)/5, ForceMode2D.Impulse);
	}

	void prepareNextWave() {
		nextWave = new List<int> ();
		totalSpawn = (wavesCount + 1) * 3;
		totalSpawn = totalSpawn > maxSpawn ? maxSpawn : totalSpawn;
		int toAdd = totalSpawn;
		toSpawn = 0;;

		for (int i = 0; toAdd > 0 && i < ennemies.Length && i < waveMap.Length; i++) {
			int toAddType;
			if (toAdd <= waveMap[i]) {
				toAddType = toAdd;
				toAdd = 0;
			} else {
				toAddType = waveMap[i];
				toAdd -= waveMap[i];
				print (i);
				if (i == waveMap.Length - 1) {
					waveBase++;
				}
			}
			toSpawn += toAddType;
			nextWave.Add (toAddType);
		}
	}


	int GenerateCornerPositionAndDirection(out Vector3 position, out Quaternion direction, bool force_corner, int corner)
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

		Vector2 point = Camera.main.ViewportToWorldPoint(new Vector3(x_dir, y_dir, 0.0f)) - position;
		direction = Quaternion.Euler (point.x, point.y, 0.0f);
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
}
