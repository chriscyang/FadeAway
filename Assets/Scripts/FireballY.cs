using UnityEngine;
using System.Collections;

public class FireballY : MonoBehaviour
{
	private int speed = 3;
	private bool moveDown;
	public AudioClip clip;

	void Start ()
	{
		moveDown = false;
	}

	void Update ()
	{
		if (moveDown) {
			gameObject.GetComponent<Animator> ().runtimeAnimatorController = Resources.Load ("fbD") as RuntimeAnimatorController;
			transform.Translate (Vector3.down * speed * Time.deltaTime);
		} else {
			gameObject.GetComponent<Animator> ().runtimeAnimatorController = Resources.Load ("fbU") as RuntimeAnimatorController;
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		}
	}

	public void reverseDirection ()
	{
		moveDown = !moveDown;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Wall") {
			reverseDirection ();
		}
	}
}
