using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEye : AbilityBase
{
	private int shootCount = 0;
	protected override void Init()
	{
		form = Skillform.WhenShoot;
		shootCount = 0;
	}
	protected override void Activity()
	{
		//GameManager.instance.player.speed *= 2
		//GameManager.instance.player.damage *= 2
		//GameManager.instance.player.scale *= 2
	}
	protected override bool Condition()
	{
		return shootCount % 4 == 0;
	}
	private void Reset()
	{
		//if(shootCount % 4 == 1)
		//{
		//	GameManager.instance.player.speed /= 2;
		//	GameManager.instance.player.damage /= 2;
		//	GameManager.instance.player.scale /= 2;
		//}
	}
	public override void LearnSkill()
	{
		base.LearnSkill();
		//GameManager.instance.player.shooter.OnShoot.AddListener(()=>{ ++shootCount;});
		//GameManager.instance.player.shooter.OnShoot.AddListener(()=>{ Reset});
	}
}
