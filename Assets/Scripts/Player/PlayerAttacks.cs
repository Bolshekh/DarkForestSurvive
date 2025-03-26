using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{

	Animator animator;
	void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void Attack()
	{
		animator.Play("Swinging");
	}
	public void Defend()
	{
		animator.Play("Parrying");
	}
}
