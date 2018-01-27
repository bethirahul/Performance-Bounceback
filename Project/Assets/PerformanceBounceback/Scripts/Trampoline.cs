using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public ParticleSystem pSystem;
	public GameManager gameManager;

	/*//   S T A R T																										
	void Start()
	{
		///gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		///pSystem = GetComponentInChildren<ParticleSystem>();
	}
	
	//   U P D A T E																									
	void Update()
	{
        ///scoreScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        ///pSystem = GetComponentInChildren<ParticleSystem>();
	}*/

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            //Score Point
			gameManager.score++;
            //Particle effect
            pSystem.Play();

            Debug.Log("Trampoline Hit");
        }
    }
}
