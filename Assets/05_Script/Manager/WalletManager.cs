using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class WalletManager : MonoBehaviour
{
    int curMoney = 3000;
	private TextMeshProUGUI moneyTxt;
	[SerializeField]
	private TextMeshProUGUI notifyTxt;

	Coroutine c;

	private void Awake()
	{
		moneyTxt = GetComponentInChildren<TextMeshProUGUI>();
		moneyTxt.text = curMoney.ToString();
		notifyTxt.alpha = 0;
	}
	public void NotEnoughMoney()
	{
		if(c != null)
		{
			StopCoroutine(c);
		}
		c = StartCoroutine(OnOff(notifyTxt, 0.1f));
	}
	public void AddMoney(int amount)
	{
		curMoney += amount;
		moneyTxt.text = curMoney.ToString();
	}
	public bool UseMoney(int amount)
	{
		if(curMoney < amount)
		{
			return false;
		}
		curMoney -= amount;
		moneyTxt.text = curMoney.ToString();
		return true;
	}

	IEnumerator OnOff(TextMeshProUGUI tmp, float t)
	{
		for (int i = 0; i < 3; i++)
		{
			yield return Fade(tmp, t, true);
			yield return Fade(tmp, t, false);
		}
		
	}

	IEnumerator Fade(TextMeshProUGUI tmp, float t, bool on)
	{
		float time = 0;
		while(t > time)
		{
			yield return null;
			time += Time.unscaledDeltaTime;
			if (on)
			{
				tmp.alpha = Mathf.Lerp(0, 1, time / t);
			}
			else
			{
				tmp.alpha = Mathf.Lerp(1, 0, time / t);
			}
			
		}
	}
}
