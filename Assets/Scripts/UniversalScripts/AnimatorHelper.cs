using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHelper : MonoBehaviour
{
	Animator animator;
	int currentState;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	private void Update()
	{
		
	}

	public void PlayAnimation(int StateHash, float TransitionDuration)
	{
		animator.CrossFade(StateHash, TransitionDuration);
	}

}
