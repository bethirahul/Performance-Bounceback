using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Rigidbody rigidbody;
	private Vector3 vector3_zero = Vector3.zero;
	private bool ballStopped;
	private float timeStopped;
	public float lowestSpeed;
	public float timeToReset;

	void Awake()
	{
		gameObject.SetActive(false);
	}

	public void Activate(Vector3 startingPosition)
	{
		
		rigidbody.velocity = vector3_zero;
		rigidbody.angularVelocity = vector3_zero;
		transform.position = startingPosition;
		gameObject.SetActive(true);
		ballStopped = false;
	}

	/*public void Deactivate()
	{
		
	}*/

	void Update()
	{
		if(rigidbody.isKinematic == false)
		{
			if(rigidbody.velocity.magnitude <= lowestSpeed && ballStopped == false)
			{
				ballStopped = true;
				timeStopped = 0f;
			}
			else if(rigidbody.velocity.magnitude > lowestSpeed && ballStopped)
				ballStopped = false;

			if(ballStopped)
			{
				timeStopped += Time.deltaTime;
				if(timeStopped > timeToReset)
					gameObject.SetActive(false);
			}
		}
		else if(ballStopped)
			ballStopped = false;
	}
}
