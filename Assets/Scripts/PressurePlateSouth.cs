using UnityEngine;
using System.Collections;

public class PressurePlateSouth : MonoBehaviour
{
	float timeLeft = 0.5f;
	bool countDownStart = false;
	private GameObject gate;
	public AudioClip opengate_sound;


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
			Debug.Log ("Time has hit 0");
			AudioSource source = GetComponent<AudioSource> ();
			source.PlayOneShot (opengate_sound, 0.7F);

			gate = GameObject.Find ("Gate_South");
			Destroy (gate.GetComponent<Wall> ());
			Destroy (gate.GetComponent<Collider2D> ());
			Destroy (gate.GetComponent<SpriteRenderer> ());
			Destroy (this.GetComponent<SpriteRenderer> ());
			Destroy (this.gameObject);
		}
		if (countDownStart && timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			Debug.Log (timeLeft);
		} else {
			timeLeft = 0.5f;
		}
	}
}
