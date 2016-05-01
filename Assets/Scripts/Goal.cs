using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

	// Goal knows the player so we can add to their power level.
	private Player player;
	public AudioClip clip;

	void Start ()
	{
		player = FindObjectOfType (typeof(Player)) as Player;
	}

	IEnumerator OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			// Play sound effect
			AudioSource source = GetComponent<AudioSource> ();
			source.PlayOneShot (clip, 0.7F);

			player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;

			// Grant the player more power for beating the level.
			Global.AddPower (15 + Timer.GetRemainingTime ());
			Debug.Log ("Player's power level: " + Global.GetPower ());


			// Advance to the next level.
			Global.level++;
			Global.inTransition = true;
			Global.levelImageSeen = false;

			float fadeTime = GameObject.Find ("_GM").GetComponent<Fading> ().BeginFade (1);
			yield return new WaitForSeconds (fadeTime);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}


}
