using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineMovement : MonoBehaviour
{
    public Vector3 direction;/// = new Vector3(1,0,0);
    public float moveSpeed;/// = 3.5f;
    public float moveTime;/// = 3f;
    private float time;
    public Rigidbody rigidbody;
	
	//   U P D A T E																									
	void Update()
	{
        time += Time.deltaTime;
        if(time > moveTime)
        {
            time = 0;
            direction = direction * -1;
        }
        rigidbody.position += direction * Time.deltaTime * moveSpeed;
	}
}
