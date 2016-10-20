using UnityEngine;
using System.Collections;

public class L5Wall : MonoBehaviour
{
	void Start ()
	{
		// Empty.
	}

	void Update ()
	{
		// Empty.
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Platform") {
			other.SendMessage ("reverseDirection");
		}
	}
}
