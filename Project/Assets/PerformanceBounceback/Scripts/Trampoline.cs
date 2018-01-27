using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public ParticleSystem pSystem;
	public GameManager GM;

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
			GM.score++;
            //Particle effect
            pSystem.Play();

            GM.Debug_Log("Trampoline Hit");
        }
    }
}
