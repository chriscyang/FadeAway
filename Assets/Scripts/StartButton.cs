using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

	public AudioClip startClip;

	public void Trigger ()
	{
		AudioSource source = GetComponent<AudioSource> ();
		source.PlayOneShot (startClip, 0.7F);

		StartCoroutine (moveScene ());
	}

	public IEnumerator moveScene ()
	{
		Global.level = 1;
		Global.levelImageSeen = false;
		float fadeTime = GameObject.Find ("_GM").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
