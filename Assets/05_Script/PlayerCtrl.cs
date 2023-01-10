using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCtrl : MonoBehaviour
{
	public bool isComputer = true;


	[SerializeField]
    private float jumpPower = 5f;
	[SerializeField]
	private int jumpCount = 2;
	public LayerMask ignoreLayer;
	public UnityEvent OnJump;
	internal Shoot shooter;
	internal PlayerHp hp;
	Rigidbody2D rig;
	int curJumpCount;
	bool isGrounded = true;
	bool prevGrounded;

	
	private void Awake()
	{
		rig = GetComponent<Rigidbody2D>();
		curJumpCount = jumpCount;
		prevGrounded = isGrounded;
		ignoreLayer = ~ignoreLayer;
		shooter = GetComponentInChildren<Shoot>();
		hp = GetComponent<PlayerHp>();
	}
	private void Update()
	{
		if(isComputer && Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}
	public void Jump()
	{
		if(curJumpCount > 0)
		{
			rig.velocity = Vector2.zero;
			rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
			--curJumpCount;
			OnJump?.Invoke();
		}
	}
	private void FixedUpdate()
	{
		if(Physics2D.BoxCast(transform.position, transform.localScale, 0, Vector2.down, 0.5f, ignoreLayer))
		{
			prevGrounded = isGrounded;
			isGrounded = true;
		}
		else
		{
			prevGrounded = isGrounded;
			isGrounded = false;
		}
		if(isGrounded != prevGrounded)
		{
			if (isGrounded)
			{
				curJumpCount = jumpCount;
			}
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position + Vector3.down * 0.5f, transform.localScale);
	}
}
