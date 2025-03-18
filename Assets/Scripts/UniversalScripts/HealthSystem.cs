using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHitable
{
	[SerializeField] float healthPoints = 3f;
	[SerializeField] float maxHealthPoints = 3f;

	public event EventHandler<BeforeEntityHitEventArgs> BeforeEntityHit;
	public event EventHandler EntityHit;
	public event EventHandler EntityDied;
	public event EventHandler<EntityHealedEventArgs> EntityHealed;
	public HitResponse Hit(HitInfo hitInfo)
	{
		BeforeEntityHitEventArgs _beh = new BeforeEntityHitEventArgs();
		BeforeEntityHit?.Invoke(gameObject, _beh);

		if (_beh.IsCancelled) return HitResponse.Ignore;

		healthPoints -= hitInfo.Damage;
		EntityHit?.Invoke(gameObject, EventArgs.Empty);
		if(healthPoints <= 0)
		{
			Debug.Log($"Entity {gameObject.name} DIED");
			EntityDied?.Invoke(gameObject, EventArgs.Empty);
		}
		return HitResponse.Hit;
	}
	public void Heal(int Points)
	{
		EntityHealed?.Invoke(gameObject, new EntityHealedEventArgs() { PointsHealed  = Points, IsEntityHealed = healthPoints < maxHealthPoints });
		if (healthPoints < maxHealthPoints)
			healthPoints += Points;

	}
}
