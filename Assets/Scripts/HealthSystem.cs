using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHitable
{
	[SerializeField] float healthPoints = 3f;
	[SerializeField] float maxHealthPoints = 3f;
	public event EventHandler EntityHit;
	public event EventHandler EntityDied;
	public event EventHandler<EntityHealedEventArgs> EntityHealed;
	public void Hit(HitInfo hitInfo)
	{
		healthPoints -= hitInfo.Damage;
		EntityHit?.Invoke(this, EventArgs.Empty);
		if(healthPoints <= 0)
		{
			Debug.Log($"Entity {gameObject.name} DIED");
			EntityDied?.Invoke(this, EventArgs.Empty);
			Destroy(gameObject);
		}
	}
	public void Heal(int Points)
	{
		EntityHealed?.Invoke(this, new EntityHealedEventArgs() { PointsHealed  = Points, IsEntityHealed = healthPoints < maxHealthPoints });
		if (healthPoints < maxHealthPoints)
			healthPoints += Points;

	}
}
