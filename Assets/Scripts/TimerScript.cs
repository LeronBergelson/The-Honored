using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerScript : MonoBehaviour {
	public Text timerText;
	private float time = 600;
	[SerializeField] string levelToLoad;

	void Start ()
	{
		StartCoundownTimer();
	}

	void StartCoundownTimer()
	{
		if (timerText != null)
		{
			time = 600;
			timerText.text = "Time Left: 20:00:000";
			InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
		}
	}

	void UpdateTimer()
	{
		if (timerText != null)
		{
			time -= Time.deltaTime;
			string minutes = Mathf.Floor(time / 60).ToString("00");
			string seconds = (time % 60).ToString("00");
			timerText.text = "Time Left: " + minutes + ":" + seconds;
			if(time <= 0){
				Cursor.visible = true;
				DoSceneChange ();

			}

		}
	}

	public void DoSceneChange()
	{
		SceneManager.LoadScene(levelToLoad);
	}
}