using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IHitable
{
	Rigidbody2D playerRB;
	Vector2 moveDirection;

	//basic movement
	[SerializeField] float moveSpeed;
	[SerializeField] float speedMultiplier;
	[SerializeField] float moveDumping = 0.8f;
	[SerializeField] float moveFree = 5f;
	[SerializeField] AnimationCurve forceMultiplier;
	float GetForceMultiplierValue(float value) => forceMultiplier.Evaluate(value);
	void Start()
	{
		playerRB = GetComponent<Rigidbody2D>();
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
			playerRB.AddForce(moveSpeed * speedMultiplier * GetForceMultiplierValue(playerRB.velocity.magnitude) * moveDirection, ForceMode2D.Force);
		}
	}

	public void Hit(GameObject WhoHits)
	{
		playerRB.AddForce((transform.position - WhoHits.transform.position) * 10, ForceMode2D.Impulse);
	}
}
