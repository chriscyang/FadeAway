using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class L5Player : Player
{

	bool platformEntered;
	bool deathzoneEntered;

	// Use this for initialization
	void Start ()
	{
		platformEntered = true;
		deathzoneEntered = false;
	}

	// Update is called once per frame
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

			float x_value = other.GetComponent<Transform> ().position.x;
			float y_value = this.GetComponent<Transform> ().position.y;
			float z_value = this.GetComponent<Transform> ().position.z;
			Vector3 new_positions = new Vector3 (x_value, y_value, z_value);

			transform.position = Vector3.MoveTowards (transform.position, new_positions, (speed + 1) * Time.deltaTime);
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
