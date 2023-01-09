using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class BulletFly : MonoBehaviour
{
	float damage = 10;
	Vector3 initSize;
	Rigidbody2D rig;
	public int playerLayer = 10;
	private void OnEnable()
	{
		initSize = transform.localScale;
		rig = GetComponent<Rigidbody2D>();
		rig.velocity = Vector2.zero;
	}
	public void ShootStart(float pow, float dam, float siz)
	{
		transform.localScale = initSize * siz;
		damage = dam;
		rig.AddForce(-transform.right * pow, ForceMode2D.Impulse);
	}
	void ReturnFunc()
	{
		rig.velocity = Vector2.zero;
		transform.localScale = initSize;
		FAED.Push(gameObject);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.layer != playerLayer)
		{
			Classs.EnemyRoot e;
			if (e = collision.GetComponent<Classs.EnemyRoot>())
			{
				e.TakeDamage(damage);
			}
			Debug.Log(collision.name);
			ReturnFunc();

		}
		
	}
}
