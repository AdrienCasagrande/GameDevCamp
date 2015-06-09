using UnityEngine;
using System.Collections;

public class Garbage : MonoBehaviour
{

	public GameObject[] prefab;

	private int size_ = 1;
	private int type;
	private bool is_alive_;


	public bool isAlive() {
		return is_alive_;
	}

	public void SetSize(int size) {
		size_ = size;
	}

	// Use this for initialization
	void Start ()
	{
		is_alive_ = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnCollisionEnter2D(Collision2D c) {
		int score = 0;
		switch (size_)
		{
		case 1:
			score = 100;
			break;
		case 2:
			score = 50;
			break;
		case 3:
			score = 20;
			break;
		}
	}
}

