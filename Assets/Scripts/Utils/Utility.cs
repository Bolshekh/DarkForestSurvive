using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealedEventArgs : EventArgs
{
	public int PointsHealed;
	/// <summary>
	/// If player was in fact healed. If player had max health he will recieve heal, but will not be getting any healing
	/// </summary>
	public bool IsPlayerHealed;
}