using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeChecker : MonoBehaviour
{
	[SerializeField]
	bool isShower = false;
	float endTime = 0;
	TextMeshProUGUI txt;
	private void Awake()
	{
		if (isShower)
		{
			On();
		}
	}
	public void RecordStart()
	{
		PlayerPrefs.SetFloat("START", Time.realtimeSinceStartup);
		Debug.Log(Time.realtimeSinceStartup);
		
	}
	public void RecordEnd()
	{
		PlayerPrefs.SetFloat("END", Time.realtimeSinceStartup);
		Debug.Log(Time.realtimeSinceStartup);
	}
	public void On()
	{
		txt = GetComponentInChildren<TextMeshProUGUI>();
		float sec = Mathf.Round(PlayerPrefs.GetFloat("END", 0) - PlayerPrefs.GetFloat("START", 0));
		int hour = (int)sec / 3600;
		sec %= 3600;
		int min = (int)sec / 60;
		sec %= 60;
		string showTxt = "";
		if(hour > 0)
		{
			showTxt += $"{hour} Ω√∞£ ";
		}
		if (min > 0)
		{
			showTxt += $"{min} ∫– ";
		}
		showTxt += $"{sec} √  µµ∏¡√∆¥Ÿ!";
		txt.text = showTxt;
		txt.enabled = true;
	}
}
