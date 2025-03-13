using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon : MonoBehaviour
{
	[SerializeField] float weaponDamage;
	public float Damage => weaponDamage;
	public event EventHandler<WeaponHitEventArgs> WeaponHit;
	void Start()
	{
		WeaponHit += (s, e) =>
		{
			e.Hit.Hit(new HitInfo() { Damage = this.Damage, Hitter = gameObject, Weapon = this });
		};
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("weapon hit");
		var _hit = collision.GetComponent<IHitable>();
		if (_hit != null)
		{
			WeaponHit?.Invoke(this, new WeaponHitEventArgs() { Hit = _hit, Collision = collision });
		}
	}
}