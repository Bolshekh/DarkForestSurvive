using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyProjectile : MonoBehaviour, IHitable
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
		var _hit = collision.GetComponent<IHitable>();
		if (_hit != null)
		{
			_hit.Hit(new HitInfo() { Damage = 1, Hitter = this.gameObject });
			collision.GetComponent<Rigidbody2D>()?.AddForce((collision.transform.position - gameObject.transform.position) * 10, ForceMode2D.Impulse);

		}
		Destroy(gameObject);
	}

	public void Hit(HitInfo hitInfo)
	{
		Destroy(gameObject);
	}
}
