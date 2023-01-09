using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : AbilityBase
{
	protected override void Init()
	{
		form = Skillform.Continuous;
	}
	protected override void Activity()
	{
		//GameManager.instance.player.shoot.shootNum += 4;
		//GameManager.instance.player.shoot.angleJitter += 15;
	}
	protected override bool Condition()
	{
		return base.Condition();
	}
}
