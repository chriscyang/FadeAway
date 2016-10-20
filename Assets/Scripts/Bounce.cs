using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour
{
	Vector3 direction;
	float speed;

	float min, max;
	float unit = 0.03f;

	void Start ()
	{
		max = transform.position.y;
		min = transform.position.y - unit;

		direction = Vector3.down;
	}

	void Update ()
	{
		if (direction == Vector3.down) {
			speed = 0.5f;
		} else {
			speed = 0.05f;
		}

		transform.Translate (direction * speed * Time.deltaTime);

		if (transform.position.y >= max) {
			direction = Vector3.down;
		}
		if (transform.position.y <= min) {
			direction = Vector3.up;
		}
	}
}
