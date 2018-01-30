using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	public bool spawnBall;
    public static BallSpawner current;

    public GameObject pooledBallPrefab; //the prefab of the object in the object pool
    [Tooltip("Number of Balls you want in the object pool when game starts")]
    public int initialBallsLimit;// = 20; //the number of objects you want in the object pool when game starts
    public List<Ball> ball; //the object pool
    public static int currentBallNum = -1; //a number used to cycle through the pooled objects
    private int count;

    private float cooldown;
	[Tooltip("Interval between spawning balls")]
    public float cooldownLength = 0.5f;

    public GameManager GM;
    private int i;

    void Awake()
    {
        current = this; //makes it so the functions in ObjectPool can be accessed easily anywhere
    }

    //   S T A R T																										
    void Start()
    {
        //Create ball List
        ball = new List<Ball>();
		for (i = 0; i < initialBallsLimit; i++)
			AddNewBall(i);
    }

    private void AddNewBall(int ballNum)
	{
		GameObject newBallGameObject = Instantiate(pooledBallPrefab);
		Ball newBall = newBallGameObject.GetComponent<Ball>();
		ball.Add(newBall);
	}

	private void SpawnBall()
	{
		currentBallNum++;
		count = 0;
		while(count < ball.Count)
		{
			if(currentBallNum >= ball.Count)
				currentBallNum = 0;
			if(ball[currentBallNum].gameObject.activeSelf == false || ball[currentBallNum].ballStopped)
			{
				ball[currentBallNum].Activate(transform.position);
				///GM.Debug_Log("Found ball " + currentBallNum + " to activate; Searched " + count + " balls");
				return;
			}
			currentBallNum++;
			count++;
		}
		AddNewBall(ball.Count);// if this comes to this line, then all the balls in the list are active
		// so, expanding the ball list by 1
		///GM.Debug_Log("All balls are active. Generated new ball; Total balls = " + ball.Count);
		ball[ball.Count-1].Activate(transform.position);
		currentBallNum = -1;

		/*if(currentBallNum >= pooledBalls.Count)
		{
			GM.Debug_Log("Balls Exceded initial limit of " + pooledBalls.Count);
			for(int i = 0; i < pooledBalls.Count; i++)
			{
				if(pooledBalls[i].activeSelf == false)
				{
					currentBallNum = i;
					ResetBall(i);
				}
			}
	    }*/
	    /*//if we’ve run out of objects in the pool too quickly, create a new one
	    if (pooledBalls[ballPoolNum].activeInHierarchy)
	    {
	    	GM.Debug_Log(ballPoolNum + " is still active");
	        //create a new bullet and add it to the bulletList
	        GameObject obj = Instantiate(pooledBall);
	        pooledBalls.Add(obj);
	        ballsAmount++;
	        ballPoolNum = ballsAmount - 1;
	    }
	    GM.Debug_Log("Pooled Ball Number: " + ballPoolNum);
	    return pooledBalls[ballPoolNum];*/
	}
   	
	//   U P D A T E																									
	void Update()
	{
		if(spawnBall)
		{
			cooldown -= Time.deltaTime;
			if(cooldown <= 0)
			{
				cooldown = cooldownLength;
				SpawnBall();
			}
		}	
	}

    /*void SpawnBall()
    {
        GameObject selectedBall = BallSpawner.current.GetPooledBall();
        selectedBall.transform.position = transform.position;
        Rigidbody selectedRigidbody = selectedBall.GetComponent<Rigidbody>();
		selectedRigidbody.velocity = vector3_zero;
		selectedRigidbody.angularVelocity = vector3_zero;
        selectedBall.SetActive(true);
    }*/
}
