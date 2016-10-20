using UnityEngine;
using System.Collections;

public class PressurePlateNorth : MonoBehaviour
{
	float timeLeft = 0.5f;
	bool countDownStart = false;
	private GameObject gate;

	public AudioClip gateOpenSound;

	void OnTriggerEnter2D (Collider2D other)
	{
		countDownStart = true;
	}

	void OnTriggerExit2D (Collider2D other)
	{
		countDownStart = false;
	}

	void Update ()
	{
		if (timeLeft <= 0) {
			AudioSource source = GetComponent<AudioSource> ();
			source.PlayOneShot (gateOpenSound, 0.7f);

			gate = GameObject.Find ("Gate_North");
			Destroy (gate.GetComponent<Wall> ());
			Destroy (gate.GetComponent<Collider2D> ());
			Destroy (gate.GetComponent<SpriteRenderer> ());
			Destroy (this.GetComponent<SpriteRenderer> ());
			Destroy (this.gameObject);
		}

		if (countDownStart && timeLeft > 0) {
			timeLeft -= Time.deltaTime;
		} else {
			timeLeft = 0.5f;
		}
	}
}
