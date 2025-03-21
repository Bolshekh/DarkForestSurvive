using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		HealthSystem _healthSystem = GetComponent<HealthSystem>();

		_healthSystem.BeforeEntityHit += (s, e) =>
		{
			if (e.HitInfo.Hitter.tag == "Player")
				e.IsCancelled = true;
		};
		_healthSystem.EntityHit += (s, e) =>
		{
			TimeManager.Manager.SlowMotion(250);
		};
	}
}