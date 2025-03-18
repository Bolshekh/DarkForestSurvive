using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInit : MonoBehaviour
{
	[SerializeField] ParticleSystem particles;
	// Start is called before the first frame update
	void Start()
	{
		HealthSystem _healthSystem = GetComponent<HealthSystem>();
		_healthSystem.BeforeEntityHit += (s, e) =>
		{
			if (e.HitInfo.Hitter.tag == "Enemy")
				e.IsCancelled = true;
		};
		_healthSystem.EntityHit += (s, e) =>
		{
			UseHitParticles();
		};
		_healthSystem.EntityDied += (s, e) =>
		{
			EnemyMovement _enemyMovement = GetComponent<EnemyMovement>();
			_enemyMovement.SetDyingLogicToAi();
			Destroy(gameObject, 0.3f);
		};
	}

	void UseHitParticles()
	{
		particles.Play();
	}
}
