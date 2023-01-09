using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEye : AbilityBase
{
	private int shootCount = 0;
	private bool isFirst = true;
	protected override void Init()
	{
		form = Skillform.WhenShoot;
		shootCount = 0;
	}
	protected override void Activity()
	{
		GameManager.instance.player.shooter.speed *= 2;
		GameManager.instance.player.shooter.damage *= 2;
		GameManager.instance.player.shooter.scale *= 2;
	}
	protected override bool Condition()
	{
		return shootCount % 4 == 2;
	}
	private void Reset()
	{
		if (shootCount % 4 == 3)
		{
			GameManager.instance.player.shooter.speed /= 2;
			GameManager.instance.player.shooter.damage /= 2;
			GameManager.instance.player.shooter.scale /= 2;
		}
	}
	public override void LearnSkill()
	{
		if (isFirst)
		{
			GameManager.instance.player.shooter.OnShoot.AddListener(() => { ++shootCount; });
			isFirst = false;
		}

		base.LearnSkill();
		GameManager.instance.player.shooter.OnShoot.AddListener(Reset);
		
		
	}
}
