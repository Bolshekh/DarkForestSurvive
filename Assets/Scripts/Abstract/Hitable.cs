using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable
{
	public void Hit(HitInfo hitInfo);
}
