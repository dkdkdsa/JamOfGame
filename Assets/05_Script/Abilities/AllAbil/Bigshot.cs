using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigshot : AbilityBase
{
	protected override void Init()
	{
		form = Skillform.Continuous;
	}
	protected override void Activity()
	{
		//GameManager.instance.player.shooter.scale *= 1.5f;
	}
}
