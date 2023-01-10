using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealJump : AbilityBase
{
	protected override void Init()
	{
		base.Init();
		form = Skillform.WhenJump;
	}
	protected override void Activity()
	{
		GameManager.instance.player.hp.HealDamage(12);
	}
	protected override bool Condition()
	{
		return base.Condition();
	}
}
