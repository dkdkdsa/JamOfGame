using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGiver : MonoBehaviour
{
	AbilityBase skill;
	private void Awake()
	{
		skill = GetComponent<AbilityBase>();
	}
	public void SkillGet()
	{
		skill.LearnSkill();
	}
}
