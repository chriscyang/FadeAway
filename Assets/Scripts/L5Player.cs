using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class L5Player : Player
{
	bool platformEntered;
	bool deathzoneEntered;

	void Start ()
	{
		platformEntered = true;
		deathzoneEntered = false;
	}

	void Update ()
	{
		if (!platformEntered && deathzoneEntered) {
			base.Die ();
		}

		base.Update ();
	}

	void circleMovement (bool moveleft)
	{
		if (moveleft) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		} else {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		OnTriggerStay2D (other);
	}

	void OnTriggerStay2D (Collider2D other)
	{
		// Move our position a step closer to the target.
		string tagName = other.tag;
		if (tagName == "Platform") {
			platformEntered = true;

			float x = other.GetComponent<Transform> ().position.x;
			float y = this.GetComponent<Transform> ().position.y;
			float z = this.GetComponent<Transform> ().position.z;
			Vector3 newPos = new Vector3 (x, y, z);

			transform.position = Vector3.MoveTowards (transform.position, newPos, (speed + 1) * Time.deltaTime);
		} else if (tagName == "Deathzone") {
			deathzoneEntered = true;

		} else if (tagName == "Finish") {
			deathzoneEntered = false;
			platformEntered = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Platform") {
			platformEntered = false;
		}
	}
}
