using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AnimatorHelper : MonoBehaviour
{
	Animator animator;
	int currentState;
	bool isCurrentStateLocked = false;
	bool isCurrentStateInterruptable = false;
	int idleState = Animator.StringToHash("Idle");
	List<Task> animationQueue = new List<Task>();
	CancellationTokenSource cts = new CancellationTokenSource();
	private void Start()
	{
		animator = GetComponent<Animator>();
		Animate();
	}
	private void Update()
	{
	}
	async void Animate()
	{
		while (true)
		{
			for (int i = animationQueue.Count - 1; i >= 0; i--)
			{
				try
				{
					Debug.Log($"anim started");
					await animationQueue[0];
					if (animationQueue[0].IsCompleted) Debug.Log($"anim completed");
					animationQueue.RemoveAt(0);
				}
				catch (OperationCanceledException)
				{
					break;
				}
			}
			//if (animationQueue.Count > 0)
			//	animationQueue.Clear();

			await Task.Delay(100);
		}
	}
	public void PlayAnimation(HelperAnimation[] animations)
	{
		foreach (HelperAnimation animation in animations)
			if (!isCurrentStateLocked || (isCurrentStateInterruptable && animation.Interruptor))
			{
				isCurrentStateLocked = animation.LockAnimation;
				isCurrentStateInterruptable = animation.InterruptableAnimation;

				if (isCurrentStateLocked && isCurrentStateInterruptable && animation.Interruptor)
				{
					cts.Cancel();
					animationQueue.Clear();
				}

				animationQueue.Add(CrossFade(
					animation.StateName,
					(isCurrentStateInterruptable && animation.Interruptor) ? animation.TransitionDuration + 0.15f : animation.TransitionDuration,
					animation.LockAnimation,
					animation.InterruptableAnimation,
					animation.Interruptor,
					cts.Token));
			}

	}
	AnimationClip FindClip(string AnimName, AnimationClip[] Clips)
	{
		var clip = Clips.Where(a => a.name == AnimName).First();
		
		if (clip == null) return Clips[0];

		return clip;
	}
	async Task CrossFade(string StateName, float TransitionDuration, bool LockAnimation, bool InterruptableAnimation, bool Interruptor, CancellationToken Token)
	{
		Token.ThrowIfCancellationRequested();
		var clip = FindClip(StateName, animator.runtimeAnimatorController.animationClips);
		animator.CrossFade(StateName, TransitionDuration);
		await Task.Delay((int)(clip.length * 1000));
		isCurrentStateLocked = false;
		isCurrentStateInterruptable = false;
	}

}
