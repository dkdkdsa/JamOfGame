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
		GameManager.instance.player.shooter.DelayShoot(Random.Range(minMaxDel.x, minMaxDel.y));
	}
	protected override bool Condition()
	{
		return base.Condition();
	}
}
