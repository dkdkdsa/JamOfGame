using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stronger : AbilityBase
{
	protected override void Init()
	{
		base.Init();
		form = Skillform.Continuous;
	}
	protected override void Activity()
	{
		GameManager.instance.player.shooter.damage *= 1.15f;
	}
}
