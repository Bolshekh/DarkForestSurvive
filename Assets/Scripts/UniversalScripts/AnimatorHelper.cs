using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimatorHelper : MonoBehaviour
{
	Animator animator;
	int currentState;
	[SerializeField] List<string> animHash = new List<string>();
	private void Start()
	{
		animator = GetComponent<Animator>();
		animator.runtimeAnimatorController.animationClips.ToList().ForEach(a => animHash.Add(a.name));
	}
	private void Update()
	{
		
	}

	public void PlayAnimation(int StateHash, float TransitionDuration)
	{
		animator.CrossFade(StateHash, TransitionDuration);
	}

}
