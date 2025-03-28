using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	private void Update()
	{
	}

	public async Task PlayAnimation(string StateName, float TransitionDuration = 0f, bool LockAnimation = false, bool InterruptableAnimation = false, bool Interruptor = false)
	{
		if ((!Interruptor && !isCurrentStateInterruptable && isCurrentStateLocked) 
			|| (isCurrentStateLocked && !(isCurrentStateInterruptable && Interruptor)))
		{
			Debug.Log("not playing it");
			return;
		}
		isCurrentStateLocked = LockAnimation;
		isCurrentStateInterruptable = InterruptableAnimation;
		
		await CrossFade(
			StateName,
			(isCurrentStateInterruptable && Interruptor)? 0.15f : TransitionDuration,
			LockAnimation,
			InterruptableAnimation,
			Interruptor);

	}
	AnimationClip FindClip(string AnimName, AnimationClip[] Clips)
	{
		var clip = Clips.Where(a => a.name == AnimName).First();
		
		if (clip == null) return Clips[0];

		return clip;
	}
	async Task CrossFade(string StateName, float TransitionDuration, bool LockAnimation, bool InterruptableAnimation, bool Interruptor)
	{
		var clip = FindClip(StateName, animator.runtimeAnimatorController.animationClips);
		animator.CrossFade(StateName, TransitionDuration);
		await Task.Delay((int)(clip.length * 1000));
		isCurrentStateLocked = false;
		isCurrentStateInterruptable = false;
	}

}
