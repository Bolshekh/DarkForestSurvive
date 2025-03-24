using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class IsExternalInit { }
}

public class EntityHealedEventArgs : EventArgs
{
	public int PointsHealed;
	/// <summary>
	/// If entity was in fact healed. If entity had max health he will recieve heal (true), but will not be getting any healing (false)
	/// </summary>
	public bool IsEntityHealed;
}

public class EntityHitEventArgs : EventArgs
{
	public EntityHitEventArgs(HitInfo HitInfo)
	{
		this.HitInfo = HitInfo;
	}

	public HitInfo HitInfo { get; init; }
	/// <summary>
	/// If entity hit event chould be calcelled due to something
	/// </summary>
	public bool IsCancelled { get; set; }
	public float HealthBefore { get; set; }
	public float HealthAfter { get; set; }
}

public class WeaponHitEventArgs : EventArgs
{
	public IHitable Hit { get; init; }
	public Collider2D Collision { get; init; }
}

public class HitInfo
{
	public Weapon Weapon;
	/// <summary>
	/// Gameobject that hits victim
	/// </summary>
	public GameObject Hitter { get; init; }
	public float Damage { get; init; }
}

[Flags]
public enum HitResponse
{
	Hit = 1,
	Ignore = 2,
	PassThrough = 4
}