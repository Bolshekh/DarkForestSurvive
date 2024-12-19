using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rigidbody;
	Vector2 moveDirection;

	//basic movement
	[SerializeField] float moveSpeed;
	[SerializeField] float speedMultiplier;
	[SerializeField] float moveDumping = 0.8f;
	[SerializeField] float moveFree = 5f;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		CheckMovement();
	}
	void FixedUpdate()
	{
		ApplyMovement();
	}

	void CheckMovement()
	{
		var _hor = Input.GetAxis("Horizontal");
		var _vert = Input.GetAxis("Vertical");

		moveDirection = new Vector2(_hor, _vert).normalized;
	}

	void ApplyMovement()
	{
		if (moveDirection.magnitude != 0)
		{
			rigidbody.drag = moveFree;
			rigidbody.AddForce(moveSpeed * speedMultiplier * moveDirection, ForceMode2D.Force);
		}
		else
		{
			rigidbody.drag = moveDumping;
		}
	}
}
