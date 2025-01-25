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
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Hit!");
		collision.GetComponent<IHitable>()?.Hit(gameObject);

		//playerRB.AddForce((transform.position - collision.transform.position) * 50, ForceMode2D.Impulse);
	}
}
