using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : MonoBehaviour
{
	protected Skillform form;
	private void Awake()
	{
		Init();
	}
	public virtual void LearnSkill<T>() where T : AbilityBase
	{
		//T skill = GameManager.instance.player.gameObject.AddComponent<T>();
		//if(form == Skillform.WhenJump)
		//{
		//	GameManager.instance.player.OnJump.AddListener(skill.UseSkill);
		//}
		//if(form == Skillform.WhenShoot)
		//{
		//	GameManager.instance.player.shooter.OnShoot.AddListener(skill.UseSkill);
		//}
		//if(form == Skillform.Continuous)
		//{
		//	skill.Activity();
		//}
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
