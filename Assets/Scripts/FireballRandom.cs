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

		float z_change = Random.Range (45.0F, 90.0F);
		bool z_change_neg = Random.value < 0.5;
		if (z_change_neg)
			z_change *= -1;
		if (moveLeft) {
			transform.Rotate (new Vector3 (0, 0, z_change) * speed * Time.deltaTime);
		} else {
			transform.Rotate (new Vector3 (0, 0, z_change) * speed * Time.deltaTime);

		}
	}

	public void reverseDirection ()
	{
		moveLeft = !moveLeft;
		// Debug.Log (moveLeft);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Wall") {
			reverseDirection ();
		}
	}
}
