using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public bool God_Mode = true;
	protected int speed = 5;

	protected void Update ()
	{
		bool up = Input.GetKey (KeyCode.UpArrow);
		bool down = Input.GetKey (KeyCode.DownArrow);
		bool left = Input.GetKey (KeyCode.LeftArrow);
		bool right = Input.GetKey (KeyCode.RightArrow);

		if (up) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		}
		if (down) {
			transform.Translate (Vector3.down * speed * Time.deltaTime);
		}
		if (left) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		if (right) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Wall" || other.tag == "Fireball") {
			if (!Global.inTransition)
				Die ();
		}
	}

	protected void Die ()
	{
		if (!God_Mode) {
			Global.SetPower (Global.levelPowerCache);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

}

