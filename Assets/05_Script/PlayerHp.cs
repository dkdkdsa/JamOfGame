using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    internal int MaxHp;
    int prevHp;
    int currentHp;
	public UnityEvent<int> OnDamaged;
	public UnityEvent OnDead;

	private void Awake()
	{
		currentHp = MaxHp;
		prevHp = currentHp;
	}
	private void Update()
	{
		if(prevHp != currentHp)
		{
			prevHp = currentHp;
			OnDamaged.Invoke(currentHp);
			if(currentHp <= 0)
			{
				OnDead.Invoke();
			}
		}
	}
	public void GetDamage(int dam)
	{
		currentHp -= dam;
	}
}
