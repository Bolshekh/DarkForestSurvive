using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
	AnimatorHelper animatorHelper;
	Animator animator;
	PlayerWeapon weapon;
	void Start()
	{
		animator = GetComponent<Animator>();
		animatorHelper = GetComponent<AnimatorHelper>();
		weapon = GetComponentInChildren<PlayerWeapon>();
	}
	public void Attack()
	{
		HelperAnimation[] helpers = new HelperAnimation[]
		{
			new HelperAnimation("AttackPrepare", LockAnimation: true, InterruptableAnimation: true),
			//new HelperAnimation("AttackSwing", LockAnimation: true),
			//new HelperAnimation("AttackRecover", LockAnimation: true, InterruptableAnimation: true),
			//new HelperAnimation("Idle"),

		};
		animatorHelper.PlayAnimation(helpers);
	}
	public void Defend()
	{
		HelperAnimation[] helpers = new HelperAnimation[]
		{
			new HelperAnimation("ParryPrepare", LockAnimation: true, Interruptor: true),
			new HelperAnimation("ParryDefence", LockAnimation: true),
			new HelperAnimation("ParryRecover", LockAnimation: true, InterruptableAnimation: true),
			new HelperAnimation("Idle"),

		};
		animatorHelper.PlayAnimation(helpers);
	}
}
