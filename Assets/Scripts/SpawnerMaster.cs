using UnityEngine;
using System.Collections;

public class SpawnerMaster : MonoBehaviour {

	public GameObject[] prefabs;
	private GameObject[] spawners;

	void Start () {
		spawners = GameObject.FindGameObjectsWithTag ("Spawner");
		foreach(GameObject spawner in spawners)
		{
			spawner.SendMessage("InvokeSpawn", 1f);
			Debug.Log(spawner.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
