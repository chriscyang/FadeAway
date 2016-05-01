using UnityEngine;
using System.Collections;

public class FireballX : MonoBehaviour
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
		if (moveLeft) {
			//Debug.Log ("Moving left now.");
			gameObject.GetComponent<Animator> ().runtimeAnimatorController = Resources.Load ("fbL") as RuntimeAnimatorController;
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		} else {
			//Debug.Log ("Moving right now.");
			gameObject.GetComponent<Animator> ().runtimeAnimatorController = Resources.Load ("fbR") as RuntimeAnimatorController;
			transform.Translate (Vector3.right * speed * Time.deltaTime);
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
