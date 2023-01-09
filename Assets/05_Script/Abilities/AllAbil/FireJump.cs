using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireJump : AbilityBase
{
	protected override void Init()
	{
		form = Skillform.WhenJump;
	}
	protected override void Activity()
	{
		//GameManager.instance.player.shoot.FireBullet();
	}
	protected override bool Condition()
	{
		return base.Condition();
	}
}
