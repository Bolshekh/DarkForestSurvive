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
	public async void Attack()
	{
		await animatorHelper.PlayAnimation("AttackPrepare", LockAnimation: true, InterruptableAnimation: true);
		BoxCollider2D box = GetComponentsInChildren<BoxCollider2D>().Where(b => b.isTrigger).First();
		box.enabled = true;
		await animatorHelper.PlayAnimation("AttackSwing", LockAnimation: true);
		box.enabled = false;
		weapon.ClearHitList();
		await animatorHelper.PlayAnimation("AttackRecover", LockAnimation: true, InterruptableAnimation: true);
		await animatorHelper.PlayAnimation("Idle");
	}
	public async void Defend()
	{
		await animatorHelper.PlayAnimation("ParryPrepare", LockAnimation: true, Interruptor: true);
		await animatorHelper.PlayAnimation("ParryDefence", LockAnimation: true);
		await animatorHelper.PlayAnimation("ParryRecover", LockAnimation: true, InterruptableAnimation: true);
	}
}
