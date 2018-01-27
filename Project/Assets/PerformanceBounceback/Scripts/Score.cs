using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameManager gameManager;
    private Text textObject;

	//   S T A R T																										
	void Start()
	{
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		textObject = GetComponentInChildren<Text>();
	}
	
	//   U P D A T E																									
	void Update()
	{
        ///Text text = GetComponentInChildren<Text>();
		textObject.text = "Score: " + gameManager.score;///.ToString();
	}
}
