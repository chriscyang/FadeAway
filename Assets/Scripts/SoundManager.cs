using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	public AudioClip clip;

	void Awake ()
	{

		DontDestroyOnLoad (this.gameObject);
	}

	void Start ()
	{
		AudioSource source = GetComponent<AudioSource> ();
		source.PlayOneShot (clip, 0.2F);
	}
}
