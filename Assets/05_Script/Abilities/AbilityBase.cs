using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SkillGiver))]
public class AbilityBase : MonoBehaviour
{
	[SerializeField]
	Skills mySkill;
	[SerializeField]
	private string skillName;
	[SerializeField]
	private string skillDesc;
	[SerializeField]
	private int skillPrice;
	[SerializeField]
	private Color themeColor;
	public AbilData data;
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
		data = new AbilData(skillName, skillDesc, skillPrice, themeColor);
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

	public static bool operator ==(AbilityBase a, AbilityBase b)
	{
		return a.mySkill == b.mySkill;
	}
	public static bool operator !=(AbilityBase a, AbilityBase b)
	{
		return a.mySkill != b.mySkill;
	}
}
