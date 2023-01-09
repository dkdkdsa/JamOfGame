using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FD.Dev;
public class Shoot : MonoBehaviour
{
	[SerializeField]
    private float shootGap;
	[SerializeField]
	private Transform shootPos;
	[SerializeField]
	private int shootNum = 4;

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
				FAED.Pop("Bullet", shootPos.position, transform.rotation);
				OnShoot?.Invoke();
			}
		}
	}
}
