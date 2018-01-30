using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public bool showDebug;
    public float gameDuration;
    private float timeRemaining = 0;
    public bool gameEnded = true;
    public Image score_bg;

    public Text time_text;
    public Text score_text;

    public OVRInput.Controller controller;

	public Text fps_text;
    private float fpsDeltaTime;
    private int fps;

	//   S T A R T																										
	void Start()
	{
		ResetGame();
	}

	private void ResetGame()
	{
		timeRemaining = gameDuration;
		gameEnded = false;
		score = 0;
		score_text.text = score.ToString();
	}
	
	//   U P D A T E																									
	void Update()
	{
		/*if(Time.frameCount % 10 == 0)
		{
			System.GC.Collect();
		}*/

		if(!gameEnded)
		{
			timeRemaining = timeRemaining - Time.deltaTime;
			if(timeRemaining <= 0)
			{
				timeRemaining = 0;
				gameEnded = true;
				time_text.text = "<b>Time's Up!</b>";
				Debug_Log("Time's Up!");
			}
			else
				time_text.text = ((int)timeRemaining + 1).ToString();
		}

		if(OVRInput.GetDown(OVRInput.Button.Two, controller))
		{
			ResetGame();
		}

		if(OVRInput.GetDown(OVRInput.Button.Start, controller))
		{
			Application.Quit();
		}

		UpdateFPS();
	}

	public void IncrementScore(int value)
	{
		score += value;
		score_text.text = score.ToString();
		Debug_Log("Score updated to: " + score);
	}

	public void Debug_Log(string log)
	{
		if(showDebug)
			Debug.Log(log);
	}

	public void UpdateFPS()
	{
		fpsDeltaTime += (Time.unscaledDeltaTime - fpsDeltaTime) * 0.1f;
		fps = (int)(1.0f / fpsDeltaTime);
		fps_text.text = "FPS: " + fps;
	}
}