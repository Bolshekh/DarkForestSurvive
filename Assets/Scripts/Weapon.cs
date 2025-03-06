using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] float weaponDamage;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("weapon hit");
		var _hit = collision.GetComponent<IHitable>();
		if (_hit != null)
		{
			_hit.Hit(gameObject);
			collision.GetComponent<Rigidbody2D>()?.AddForce((collision.transform.position - gameObject.transform.position) * 10, ForceMode2D.Impulse);
		}
	}
}
