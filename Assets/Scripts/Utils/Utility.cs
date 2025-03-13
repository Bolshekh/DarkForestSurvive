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
	public GameObject Hitter;
	public float Damage { get; init; }
}