using UnityEngine;
using System.Collections;

public class FireballRandom : MonoBehaviour
{
	private int speed = 3;
	private bool moveLeft;
	public AudioClip clip;

	void Start ()
	{
		moveLeft = true;
	}

	void Update ()
	{
		float zDelta = Random.Range (45.0f, 90.0f);
		bool zDeltaNeg = Random.value < 0.5;

		if (zDeltaNeg) {
			zDelta *= -1;
		}

		if (moveLeft) {
			transform.Rotate (new Vector3 (0, 0, zDelta) * speed * Time.deltaTime);
		} else {
			transform.Rotate (new Vector3 (0, 0, zDelta) * speed * Time.deltaTime);
		}
	}

	public void reverseDirection ()
	{
		moveLeft = !moveLeft;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Wall") {
			reverseDirection ();
		}
	}
}
