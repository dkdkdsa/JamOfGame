using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using FD.Dev;
using UnityEngine.EventSystems;

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
	internal float maxDamage = 1000;
	[SerializeField]
	internal float maxSpeed = 150;
	[SerializeField]
	internal float maxScale = 12;
	[SerializeField]
	internal float angleJitter = 0;

	internal float damage;
	internal float speed;
	internal float scale;

	ShootState shootMode;
	public float ShootGap { get => shootGap; set => shootGap = value;}
	public UnityEvent OnShoot;

	public RectTransform jumpButton;

	Camera mainCam;
	SpriteRenderer srend;
	Coroutine shootSeq;
	Coroutine c;

	List<BulletFly> tester = new List<BulletFly>();
	private void Awake()
	{
		mainCam = Camera.main;
		srend = GetComponent<SpriteRenderer>();
		damage = baseDamage;
		speed = baseSpeed;
		scale = baseScale;
	}

	private void Update()
	{
		damage = Mathf.Clamp(damage, baseDamage, maxDamage);
		scale = Mathf.Clamp(scale, baseScale, maxScale);
		speed = Mathf.Clamp(speed, baseSpeed, maxSpeed);
		if (Input.GetMouseButtonDown(0))
		{
			if (!EventSystem.current.IsPointerOverGameObject(0))
			{
				shootSeq = StartCoroutine(Shooter());
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			StopCoroutine(shootSeq);
			shootSeq = null;
			shootMode = ShootState.None;
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
			yield return new WaitForSeconds(shootGap);
			FireBullet();
		}
	}
	IEnumerator DelayOnOff()
	{
		srend.enabled = true;
		yield return new WaitForSeconds(shootGap * 0.75f);
		srend.enabled = false;
	}
	public GameObject FireBullet()
	{
		if(c != null)
			StopCoroutine(c);
		c = StartCoroutine(DelayOnOff());
		transform.right = CalcDir();
		Debug.Log(transform.localEulerAngles.z);
		if(transform.localEulerAngles.z < 90 || transform.localEulerAngles.z > 270)
		{
			srend.flipY = false;
		}
		else
		{
			srend.flipY = true;
		}
		BulletFly bullet = null;
		if (shootNum > 1)
		{
			for (int i = 0; i < shootNum; i++)
			{
                FAED.Pop("BulletFX", shootPos.position, Quaternion.identity);
                bullet = FAED.Pop("PlayerBullet", shootPos.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, Random.Range(-angleJitter, angleJitter)))).GetComponent<BulletFly>();
				tester.Add(bullet);
				bullet.ShootStart(speed, damage, scale);
			}
            GameManager.instance.shakeManager.Shake(3, 3, 0.05f);

        }
		else
		{

			GameManager.instance.shakeManager.Shake(3, 3, 0.05f);
            FAED.Pop("BulletFX", shootPos.position, Quaternion.identity);
            bullet = FAED.Pop("PlayerBullet", shootPos.position, transform.rotation).GetComponent<BulletFly>();
			bullet.ShootStart(speed, damage, scale);
		}
		
		OnShoot?.Invoke();
		return bullet.gameObject;
	}
	public void DelayShoot(float del)
	{
		StartCoroutine(DelShoot(del));
	}
	IEnumerator DelShoot(float del)
	{
		yield return new WaitForSeconds(del);
		FireBullet();
	}
}
