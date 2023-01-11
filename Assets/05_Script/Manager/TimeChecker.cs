using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeChecker : MonoBehaviour
{
	float startTime = 0;
	float endTime = 0;
	TextMeshProUGUI txt;
	private void Awake()
	{

	}

	public void RecordStart()
	{
		startTime = Time.time;
	}
	public void RecordEnd()
	{
		endTime = Time.time;
		txt.text = $"{endTime - startTime} √  µµ∏¡√∆¥Ÿ!";
		txt.enabled = true;
	}
	public void Off()
	{
		txt.enabled = false;
	}
}
