using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] GameObject projectile;

	[SerializeField] int delayBetweenShots = 300;
	// Start is called before the first frame update
	void Start()
	{
		StartShooting();
	}

	async void StartShooting()
	{
		while (true)
		{
			Instantiate(projectile);

			await Task.Delay(delayBetweenShots);
		}
	}
}
