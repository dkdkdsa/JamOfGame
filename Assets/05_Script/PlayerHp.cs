using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    internal int MaxHp;
    int currentHp;
	public UnityEvent<int> OnDamaged;
	public UnityEvent<int> OnHeal;
	public UnityEvent OnDead;

	private void Awake()
	{
		currentHp = MaxHp;
	}
	public void HealDamage(int am)
	{
		currentHp += am;
		if(currentHp > MaxHp)
		{
			currentHp = MaxHp;
		}
		OnHeal.Invoke(currentHp);
	}
	public void GetDamage(int dam)
	{
		currentHp -= dam;
		OnDamaged.Invoke(currentHp);
		if (currentHp <= 0)
		{
			OnDead.Invoke();
		}
	}
}
