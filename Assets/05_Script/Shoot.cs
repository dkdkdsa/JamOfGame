using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FD.Dev;
public class Shoot : MonoBehaviour
{
	[SerializeField]
    internal float shootGap;
	[SerializeField]
	private Transform shootPos;
	[SerializeField]
	internal int shootNum = 4;
	[SerializeField]
	internal float baseDamage = 10;
	[SerializeField]
	internal float baseSpeed = 12;
	[SerializeField]
	internal float baseScale = 1;
	[SerializeField]
	internal float angleJitter = 0;

	internal float damage;
	internal float speed;
	internal float scale;

	ShootState shootMode;
	public float ShootGap { get => shootGap; set => shootGap = value;}
	public UnityEvent OnShoot;

	Camera mainCam;
	SpriteRenderer srend;
	
	private void Awake()
	{
		mainCam = Camera.main;
		srend = GetComponent<SpriteRenderer>();
		StartCoroutine(Shooter());
		damage = baseDamage;
		speed = baseSpeed;
		scale = baseScale;
	}

	private void Update()
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			shootMode = ShootState.Continuous;
			srend.enabled = true;
		}
		if (Input.GetMouseButton(0))
		{
			transform.right = CalcDir();
		}
		if(Input.GetMouseButtonUp(0))
		{
			shootMode = ShootState.None;
			srend.enabled = false;
		}
	}

	Vector2 CalcDir()
	{
		Vector2 dir = transform.position - mainCam.ScreenToWorldPoint(Input.mousePosition);
		return dir.normalized;
	}

	IEnumerator Shooter()
	{
		while (true)
		{
			yield return null;
			if (shootMode == ShootState.Continuous)
			{
				yield return new WaitForSeconds(shootGap);
				for (int i = 0; i < shootNum; i++)
				{
					FireBullet();
				}
				
			}
		}
	}
	public GameObject FireBullet()
	{
		BulletFly bullet = FAED.Pop("Bullet", shootPos.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,Random.Range(-angleJitter, angleJitter)))).GetComponent<BulletFly>();
		bullet.ShootStart(speed, damage, scale);
		OnShoot?.Invoke();
		return bullet.gameObject;
	}
}
