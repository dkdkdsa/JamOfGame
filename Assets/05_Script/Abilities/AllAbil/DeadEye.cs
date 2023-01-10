using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEye : AbilityBase
{
	private int shootCount = 0;
	private bool isFirst = true;
	Vector3 prevData = new Vector3();
	protected override void Init()
	{
		base.Init();
		form = Skillform.WhenShoot;
		shootCount = 0;
	}
	protected override void Activity()
	{
		prevData.x = GameManager.instance.player.shooter.speed;
		prevData.y = GameManager.instance.player.shooter.damage;
		prevData.z = GameManager.instance.player.shooter.scale;
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
			GameManager.instance.player.shooter.speed = prevData.x;
			GameManager.instance.player.shooter.damage = prevData.y;
			GameManager.instance.player.shooter.scale = prevData.z;
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
