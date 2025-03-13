using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
	EnemyMovement enemyMovement;
	Animator animator;
	// Start is called before the first frame update
	void Start()
	{
		enemyMovement = GetComponent<EnemyMovement>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (enemyMovement.IsInAttackDistance)
		{
			animator.Play("Attack");
		}
	}
}
