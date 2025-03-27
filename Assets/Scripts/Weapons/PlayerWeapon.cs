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
			e.Hit.Hit(new HitInfo() { Damage = this.Damage, Hitter = gameObject, Weapon = this });
			List<ContactPoint2D> _contacts = new List<ContactPoint2D>();
			e.Collision.GetContacts(_contacts);
			e.Collision.attachedRigidbody
			.AddForce((e.Collision.transform.position - (Vector3)_contacts[0].point) * Knockback, ForceMode2D.Impulse);
		};
	}
}
