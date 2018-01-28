﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Throwable"))
			col.gameObject.SetActive(false);
	}
}