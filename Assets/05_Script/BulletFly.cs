using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class BulletFly : MonoBehaviour
{
	public float minPower = 12f;
	public float maxPower = 12f;
	Rigidbody2D rig;
	private void Awake()
	{
		rig = GetComponent<Rigidbody2D>();
	}
	private void OnEnable()
	{
		rig.AddForce(-transform.right * Random.Range(minPower, maxPower), ForceMode2D.Impulse);
	}
	private void OnBecameInvisible()
	{
		rig.velocity = Vector2.zero;
		FAED.Push(gameObject);
	}
}
