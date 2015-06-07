using UnityEngine;
using System.Collections;

public class SFXScript : MonoBehaviour {

	public static SFXScript instance;
	public ParticleSystem boomEffect;
	public ParticleSystem flameBurst;
	public AudioClip boomSound;

	private AudioSource audioCenter;

	void Awake() {
		if (instance != null) {
			print ("more than one instance of SFXScript, or not");
			Destroy (this.gameObject);
		} else {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void burst(Vector3 position) {
		instantiate (flameBurst, position);
	}

	public void explode(Vector3 position) {
		playSound (boomSound);
		instantiate (boomEffect, position);
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position) {
		ParticleSystem particle = Instantiate (prefab, position, Quaternion.identity) as ParticleSystem;
		Destroy (particle.gameObject, particle.startLifetime);
		return particle;
	}

	public void playSound(AudioClip sound) {
		AudioSource.PlayClipAtPoint (sound, transform.position);
	}
}
