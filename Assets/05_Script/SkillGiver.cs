using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillGiver : MonoBehaviour, IPointerDownHandler
{
	AbilityBase skill;
	TextMeshProUGUI price;
	private void Awake()
	{
		skill = GetComponent<AbilityBase>();
		price = GetComponentInChildren<TextMeshProUGUI>();
		
	}
	private void Start()
	{
		price.text = $"АЁАн : {skill.data.skillPrice}";
	}
	public void SkillGet()
	{
		if (GameManager.instance.walletManager.UseMoney(skill.data.skillPrice))
		{
			skill.LearnSkill();
		}
		else{
			GameManager.instance.walletManager.NotEnoughMoney();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		GameManager.instance.descPanel.Display(skill);
	}
}
