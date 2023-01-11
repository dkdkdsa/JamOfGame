using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shopper : MonoBehaviour
{
    public List<AbilityBase> abilities;
    List<AbilityBase> children = new List<AbilityBase>();
	GridLayoutGroup seller;
	RectTransform sellerT;

	private void Awake()
	{
		seller= GetComponentInChildren<GridLayoutGroup>();
		sellerT = seller.GetComponent<RectTransform>();
		for (int i = 0; i < abilities.Count; i++)
		{
			AbilityBase abil = Instantiate(abilities[i], seller.transform);
			children.Add(abil);
			abil.gameObject.SetActive(false);
		}
		gameObject.SetActive(false);
	}

	public void OpenShop()
	{
		gameObject.SetActive(true);
		List<AbilityBase> stock = new List<AbilityBase>( RandomPicker(children, 3));
		foreach (var item in stock)
		{
			Debug.Log(item.data.skillName);
		}
		for (int i = 0; i < children.Count; i++)
		{
				if (Contain(stock,children[i]))
				{
					children[i].gameObject.SetActive(true);
				}
				else
				{
					children[i].gameObject.SetActive(false);
				}
		}
		Time.timeScale = 0;
	}
	public void CloseShop()
	{
		gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	bool Contain(List<AbilityBase> list, AbilityBase datum)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if(list[i] == datum)
			{
				return true;
			}
		}
		return false;
	}


	List<AbilityBase> RandomPicker(List<AbilityBase> allList, int count)
	{
		List<AbilityBase> copy = new List<AbilityBase>(allList);
		List<AbilityBase> picked = new List<AbilityBase>();
		for (int i = 0; i < count; i++)
		{
			int idx = Random.Range(0, copy.Count - 1);
			picked.Add(copy[idx]);
			copy.RemoveAt(idx);
		}
		
		return picked;
	}
}
