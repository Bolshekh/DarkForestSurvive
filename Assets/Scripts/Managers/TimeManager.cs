using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	[SerializeField] float TimeScale = 0.5f; 
	public static TimeManager Manager { get; private set; }
	CancellationTokenSource cts = new CancellationTokenSource();
	private void Start()
	{
		Manager = this;
	}

	[ReadOnly][SerializeField] float timeSpeed = 1;
	List<Task> slowMotions = new List<Task>();

	public async Task SlowTime(int millisecons, CancellationToken token)
	{
		token.ThrowIfCancellationRequested();

		timeSpeed = Time.timeScale;
		Time.timeScale = TimeScale;

		await Task.Delay(millisecons);
	}

	public void SlowTime()
	{
		slowMotions.Add(SlowTime(1000, cts.Token));
		try
		{
			Task.WaitAll(slowMotions.ToArray(), cts.Token);
		}
		catch(OperationCanceledException)
		{
			Debug.Log("slow motion tasks cancelled");
		}
	}
}
