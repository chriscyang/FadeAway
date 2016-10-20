using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
	protected float fadeDuration = 2;
	private float timer = 0;

	public static bool disableCollider;

	void Start ()
	{
		disableCollider = false;
	}

	protected void Update ()
	{
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

	public void AddDuration ()
	{
		timer -= 0.6f;
	}
}
