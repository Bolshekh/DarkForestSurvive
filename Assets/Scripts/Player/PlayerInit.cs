using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInit : MonoBehaviour
{
	[SerializeField] Slider healthSlider;
	// Start is called before the first frame update
	void Start()
	{
		HealthSystem _healthSystem = GetComponent<HealthSystem>();

		_healthSystem.BeforeEntityHit += (s, e) =>
		{
			if (e.HitInfo.Hitter.transform.root.CompareTag("Player"))
				e.IsCancelled = true;
		};
		_healthSystem.EntityHit += (s, e) =>
		{
			healthSlider.value = e.HealthAfter;
			TimeManager.Manager.SlowMotion(250);
		};
	}
}