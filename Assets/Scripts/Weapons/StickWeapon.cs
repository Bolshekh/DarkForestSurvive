using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickWeapon : Weapon
{
	// Start is called before the first frame update
	void Start()
	{
		WeaponHit += (s, e) =>
		{
			e.Hit.Hit(new HitInfo() { Damage = this.Damage, Hitter = gameObject, Weapon = this });
			e.Collision.GetComponent<Rigidbody2D>()?
			.AddForce((e.Collision.transform.position - gameObject.transform.position) * 10, ForceMode2D.Impulse);
		};
	}
}
