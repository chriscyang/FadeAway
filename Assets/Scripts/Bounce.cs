using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour
{

	float speed;
	Vector3 direction;
	float min, max;
	float units = 0.03f;

	// Use this for initialization
	void Start ()
	{
		max = transform.position.y;
		min = transform.position.y - units;

		direction = Vector3.down;
	}

	// Update is called once per frame
	void Update ()
	{

		if (direction == Vector3.down)
			speed = 0.5f;
		else
			speed = 0.05f;

		transform.Translate (direction * speed * Time.deltaTime);

		if (transform.position.y >= max)
			direction = Vector3.down;
		if (transform.position.y <= min)
			direction = Vector3.up;
	}
}
