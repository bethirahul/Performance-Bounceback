using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public bool showDebug;
    public float timeRemaining;
    private bool gameEnded;

    public Text time_text;
    public Text score_text;

	//   S T A R T																										
	void Start()
	{
		score = 0;
		gameEnded = false;
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
				Debug_Log("Time's Up!");
			}
			time_text.text = ((int)timeRemaining).ToString();
		}
	}

	public void IncrementScore(int value)
	{
		score += value;
		score_text.text = value.ToString();
		Debug_Log("Score updated to: " + score);
	}

	public void Debug_Log(string log)
	{
		if(showDebug)
			Debug.Log(log);
	}
}
