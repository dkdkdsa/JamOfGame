using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AbilData
{
    public string skillName;
    public string skillDesc;
    public int skillPrice;
    public Color themeColor;

    public AbilData(string n, string desc, int price, Color theme)
	{
        skillName = n;
        skillDesc = desc;
        skillPrice = price;
        themeColor = theme;
	}
}
