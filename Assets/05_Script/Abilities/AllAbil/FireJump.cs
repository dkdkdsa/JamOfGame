using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireJump : AbilityBase
{
	[SerializeField]
	Vector2 minMaxDel;
	protected override void Init()
	{
		base.Init();
		form = Skillform.WhenJump;
	}
	protected override void Activity()
	{
		StartCoroutine(Fire());
	}
	IEnumerator Fire()
	{
		yield return new WaitForSeconds(Random.Range(minMaxDel.x, minMaxDel.y));
		GameManager.instance.player.shooter.FireBullet();
	}
	protected override bool Condition()
	{
		return base.Condition();
	}
}
