using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] GameObject projectile;

	[SerializeField] int delayBetweenShots = 300;
	[SerializeField] int projectileSpeed = 2;
	// Start is called before the first frame update
	void Start()
	{
		StartShooting();
	}

	async void StartShooting()
	{
		while (true)
		{
			var _proj = Instantiate(projectile);
			_proj.transform.position = transform.position;
			var _rb = _proj.GetComponent<Rigidbody2D>();
			_rb.velocity = projectileSpeed * transform.up;

			await Task.Delay(delayBetweenShots);
		}
	}
}
