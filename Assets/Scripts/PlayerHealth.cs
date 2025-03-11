using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHitable
{
	[SerializeField] float healthPoints = 3f;
	[SerializeField] float maxHealthPoints = 3f;
	public event EventHandler PlayerHit;
	public event EventHandler PlayerDied;
	public event EventHandler<PlayerHealedEventArgs> PlayerHealed;
	public void Hit(HitInfo hitInfo)
	{
		healthPoints -= hitInfo.Damage;
		PlayerHit?.Invoke(this, EventArgs.Empty);
		if(healthPoints <= 0)
		{
			Debug.Log("GAME OVER");
			PlayerDied?.Invoke(this, EventArgs.Empty);
		}
	}
	public void Heal(int Points)
	{
		PlayerHealed?.Invoke(this, new PlayerHealedEventArgs() { PointsHealed  = Points, IsPlayerHealed = healthPoints < maxHealthPoints });
		if (healthPoints < maxHealthPoints)
			healthPoints += Points;

	}
}
