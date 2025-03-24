using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHitable
{
	[SerializeField] float healthPoints = 3f;
	[SerializeField] float maxHealthPoints = 3f;

	public event EventHandler<EntityHitEventArgs> BeforeEntityHit;
	public event EventHandler<EntityHitEventArgs> EntityHit;
	public event EventHandler EntityDied;
	public event EventHandler<EntityHealedEventArgs> EntityHealed;
	public HitResponse Hit(HitInfo hitInfo)
	{
		EntityHitEventArgs _beh = new EntityHitEventArgs(hitInfo) { HealthBefore = healthPoints };
		BeforeEntityHit?.Invoke(gameObject, _beh);

		if (_beh.IsCancelled) return HitResponse.Ignore;

		healthPoints -= hitInfo.Damage;
		EntityHit?.Invoke(gameObject, new EntityHitEventArgs(hitInfo) 
		{
			HealthBefore = healthPoints + hitInfo.Damage, HealthAfter = healthPoints
		});

		if(healthPoints <= 0)
		{
			Debug.Log($"Entity {gameObject.name} DIED");
			EntityDied?.Invoke(gameObject, EventArgs.Empty);
		}
		return HitResponse.Hit;
	}
	public void Take1Damage()
	{
		HitInfo hitInfo = new HitInfo() { Damage = 1, Hitter = TimeManager.Manager.gameObject };
		healthPoints -= hitInfo.Damage;
		EntityHit?.Invoke(gameObject, new EntityHitEventArgs(hitInfo));
		if (healthPoints <= 0)
		{
			Debug.Log($"Entity {gameObject.name} DIED");
			EntityDied?.Invoke(gameObject, EventArgs.Empty);
		}
	}
	public void Heal(int Points)
	{
		EntityHealed?.Invoke(gameObject, new EntityHealedEventArgs() 
		{
			PointsHealed  = Points, IsEntityHealed = healthPoints < maxHealthPoints
		});

		if (healthPoints < maxHealthPoints)
			healthPoints += Points;

	}
}
