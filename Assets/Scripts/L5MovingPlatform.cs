using UnityEngine;
using System.Collections;

public class L5MovingPlatform : MonoBehaviour
{
	public bool moveLeft;
	private float timer = 0;
	private float fadeDuration = 5;

	void Start ()
	{
		moveLeft = Random.value < 0.5;
	}

	void Update ()
	{
		if (moveLeft) {
			transform.Translate (Vector3.left * 5 * Time.deltaTime);
		} else {
			transform.Translate (Vector3.right * 5 * Time.deltaTime);
		}

		// Fade the walls from red to white gradually over fadeDuration.
		Color change = this.GetComponent<SpriteRenderer> ().material.color;
		change.a = 1 - timer;
		this.GetComponent<SpriteRenderer> ().material.color = change;
		if (timer < 1) {
			timer += Time.deltaTime / fadeDuration;
		}

		// Light up the walls and reduce the player's power.
		if (Input.GetKey (KeyCode.Space) && Global.GetPower () > 0) {
			Color changeColor = this.GetComponent<SpriteRenderer> ().color;
			changeColor.a = 1.0f;
			this.GetComponent<SpriteRenderer> ().material.color = changeColor;

			Global.MinusPower (Time.deltaTime);
		}
	}

	public void reverseDirection ()
	{
		moveLeft = !moveLeft;
	}
}
