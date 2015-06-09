using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public static ScoreScript instance;
	public int currentScore = 0;
	public int xp = 0;
	public int currentWave = 0;

	// Use this for initialization
	void Start () {
		if (instance != null) {
			print ("more than one instance of Scorescript, or not");
			Destroy (this);
		} else {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addToWave(int nb) {
		currentWave += nb;
	}

	public void addToScore(int points) {
		currentScore += points;
		xp += points;
		currentWave -= 1;
	}

}
