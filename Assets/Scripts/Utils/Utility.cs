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

public class PlayerHealedEventArgs : EventArgs
{
	public int PointsHealed;
	/// <summary>
	/// If player was in fact healed. If player had max health he will recieve heal, but will not be getting any healing
	/// </summary>
	public bool IsPlayerHealed;
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