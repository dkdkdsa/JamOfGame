using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickFire : AbilityBase
{
	protected override void Init()
	{
		form = Skillform.Continuous;
	}
	protected override void Activity()
	{
		GameManager.instance.player.shooter.shootGap *= 0.5f;
	}
}
