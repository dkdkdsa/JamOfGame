using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGiver : MonoBehaviour
{
	AbilityBase skill;
    public void SkillGet(AbilityBase skill)
	{
		skill.LearnSkill();
	}
}
