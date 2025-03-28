using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Weapon
{
	// Start is called before the first frame update
	void Start()
	{
		WeaponHit += (s, e) =>
		{
			if (Hits.Contains(e.Collision.gameObject))
				return;

			Hits.Add(e.Collision.gameObject);
			var response = e.Hit.Hit(new HitInfo() { Damage = this.Damage, Hitter = gameObject, Weapon = this });
			if (response != HitResponse.Ignore)
			{
				e.Collision.attachedRigidbody
				.AddForce((e.Collision.transform.position - transform.position).normalized * Knockback, ForceMode2D.Impulse);
			}
		};
	}
}
