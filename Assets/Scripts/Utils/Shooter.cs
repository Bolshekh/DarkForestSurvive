using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] GameObject projectile;

	[SerializeField] int delayBetweenShots = 300;
	[SerializeField] int projectileSpeed = 2;

	CancellationTokenSource cts = new CancellationTokenSource();
	// Start is called before the first frame update
	async void Start()
	{
		var task = StartShooting(cts.Token);

		try
		{
			await task;
		}
		catch(OperationCanceledException) {
			Debug.Log("shooter task cancelled");
		}
	}

	private void OnDestroy()
	{
		cts.Cancel();
	}
	async Task StartShooting(CancellationToken token)
	{
		while (true)
		{
			token.ThrowIfCancellationRequested();
			var _proj = Instantiate(projectile);
			_proj.transform.position = transform.position;
			var _rb = _proj.GetComponent<Rigidbody2D>();
			_rb.velocity = projectileSpeed * transform.up;

			await Task.Delay(delayBetweenShots);
		}
	}
}
