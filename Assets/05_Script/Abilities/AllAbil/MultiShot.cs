using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : AbilityBase
{
	protected override void Init()
	{
		base.Init();
		form = Skillform.Continuous;
	}
	protected override void Activity()
	{
		GameManager.instance.player.shooter.shootNum += 4;
		GameManager.instance.player.shooter.angleJitter += 15;
		GameManager.instance.player.shooter.angleJitter = Mathf.Clamp(GameManager.instance.player.shooter.angleJitter, 0, 45);
	}
	protected override bool Condition()
	{
		return base.Condition();
	}
}
