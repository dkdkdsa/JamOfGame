using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DescPanelManager : MonoBehaviour
{
	TextMeshProUGUI descTxt;
	Image img;
	private void Awake()
	{
		descTxt = GetComponentInChildren<TextMeshProUGUI>();
		img = GetComponent<Image>();
		Off();
	}
	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			Off();
		}
	}
	public void Display(AbilityBase info)
	{
		img.enabled = true;
		descTxt.enabled = true;
		descTxt.text = info.data.skillDesc;
		img.color = info.data.themeColor;
		transform.position = Input.mousePosition;
	}
	public void Off()
	{
		img.enabled = false;
		descTxt.enabled = false;
	}
}
