using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AbilData
{
    public string skillName;
    public string skillDesc;
    public int skillPrice;
    public Sprite skillIcon;

    public AbilData(string n, string desc, int price, Sprite icon)
	{
        skillName = n;
        skillDesc = desc;
        skillPrice = price;
        skillIcon = icon;
	}
}
