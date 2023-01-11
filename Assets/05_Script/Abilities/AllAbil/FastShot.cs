using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShot : AbilityBase
{
	protected override void Init()
	{
		base.Init();
		form = Skillform.Continuous;
		
	}
	protected override void Activity()
	{
		GameManager.instance.player.shooter.speed *= 1.45f;
	}
}
