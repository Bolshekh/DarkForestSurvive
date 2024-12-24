using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyProjectile : MonoBehaviour
{
	[SerializeField] float timeToLive = 5f;
	void Start()
	{
		timeToLive += Time.time;
	}
	void Update()
	{
		if(Time.time > timeToLive)
		{
			Destroy(gameObject);
		}
	}
}
