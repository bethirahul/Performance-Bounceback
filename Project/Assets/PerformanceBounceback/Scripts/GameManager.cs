using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool showDebug;

	/*//   S T A R T																										
	void Start()
	{
		
	}*/
	
	/*//   U P D A T E																									
	void Update()
	{
		
	}*/

	public void Debug_Log(string log)
	{
		if(showDebug)
			Debug.Log(log);
	}
}
