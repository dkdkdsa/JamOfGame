using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SkillGiver))]
public class AbilityBase : MonoBehaviour
{
	protected Skillform form;
	private void Awake()
	{
		Init();
	}
	public virtual void LearnSkill()
	{
		if (form == Skillform.WhenJump)
		{
			GameManager.instance.player.OnJump.AddListener(UseSkill);
		}
		if (form == Skillform.WhenShoot)
		{
			GameManager.instance.player.shooter.OnShoot.AddListener(UseSkill);
		}
		if (form == Skillform.Continuous)
		{
			Activity();
		}
	}
	protected virtual void Init()
	{

	}
	public void UseSkill()
	{
		if (Condition())
		{
			Activity();
		}
	}
	protected virtual bool Condition()
	{
		return true;
	}
    protected virtual void Activity()
	{
		
	}
}
