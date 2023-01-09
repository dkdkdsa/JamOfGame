using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class BulletFly : MonoBehaviour
{
	float damage = 10;
	Vector3 initSize;
	Rigidbody2D rig;
	private void Awake()
	{
		initSize = transform.localScale;
		rig = GetComponent<Rigidbody2D>();
	}
	private void OnBecameInvisible()
	{
		rig.velocity = Vector2.zero;
		transform.localScale = Vector3.one;
		FAED.Push(gameObject);
	}
	public void ShootStart(float pow, float dam, float siz)
	{
		transform.localScale = initSize * siz;
		damage = dam;
		rig.AddForce(-transform.right * pow, ForceMode2D.Impulse);
	}
}
