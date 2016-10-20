using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour
{
	private Wall[] walls;

	public AudioClip powerUpSound;

	void Start ()
	{
		walls = FindObjectsOfType (typeof(Wall)) as Wall[];
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("Player collided with a charge.");

		// Play sound effect.
		AudioSource source = GetComponent<AudioSource> ();
		source.PlayOneShot (powerUpSound, 0.7f);

		foreach (Wall w in walls) {
			w.AddDuration ();
		}

		Destroy (this.GetComponent<Collider2D> ());
		Destroy (this.GetComponent<Animator> ());
		Destroy (this.GetComponent<SpriteRenderer> ());
	}
}
