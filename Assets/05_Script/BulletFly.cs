using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class BulletFly : MonoBehaviour
{
	float damage = 10;
	Vector3 initSize;
	Rigidbody2D rig;
	Collider2D col;
	public int playerLayer = 10;
	public int obstacleLayer = 14;

	private bool isHit = false;

	int devMode = 0;
	private void Awake()
	{
		devMode = 0;
		rig = GetComponent<Rigidbody2D>();
		col = GetComponent<Collider2D>();
	}
	private void OnEnable()
	{
		devMode += 1;
		initSize = transform.localScale;
		isHit = false;
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

		if(isHit) return;

		if(collision.gameObject.layer != playerLayer && collision.gameObject.layer != obstacleLayer)
		{
			Classs.EnemyRoot e;
			if (e = collision.GetComponent<Classs.EnemyRoot>())
			{
				e.TakeDamage(damage);
			}

			isHit = true;

			Debug.Log($"Returned{GetHashCode()} with useCount : {devMode} , by colliding with {collision.name}");
			ReturnFunc();
		}
	}
}
