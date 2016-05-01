using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	private float goalTime;
	private static float remainingTime;
	private string timerText;
	private double current_power;

	void Start ()
	{
		Debug.Log ("LEVEL:" + Global.level);
		goalTime = Time.time;
		remainingTime = Global.times [Global.level];
		current_power = Global.GetPower ();
	}

	void Update ()
	{
		remainingTime -= (Time.time - goalTime);
		goalTime = Time.time;

		if (remainingTime < 0) {
			DeathByTimer ();
		}

		SetTimerText (remainingTime);
		current_power = Global.GetPower ();
	}

	void DeathByTimer ()
	{
		remainingTime = Global.times [Global.level];
		SetTimerText (remainingTime * 60);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	void SetTimerText (float time)
	{
		int mm = (int)time / 60;
		int ss = (int)time % 60;
		float fraction = (time * 100) % 100;

		timerText = string.Format ("{0:00}:{1:00}:{2:00}" + "\nPower:{3:00}", mm, ss, fraction, current_power);
		this.GetComponent<Text> ().text = timerText;
	}

	public static float GetRemainingTime ()
	{
		return remainingTime;
	}
}
