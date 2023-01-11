using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    internal float MaxHp;
	[SerializeField] private Slider slider;
    float currentHp;
	public UnityEvent<float> OnDamaged;
	public UnityEvent<float> OnHeal;
	public UnityEvent OnDead;

	private void Awake()
	{
		currentHp = MaxHp;
	}

	public void HealDamage(float am)
	{
		currentHp += am;

        DOTween.To(x => slider.value = x, slider.value, currentHp / MaxHp, 0.3f).Play();

        if (currentHp > MaxHp)
		{
			currentHp = MaxHp;
		}
		OnHeal.Invoke(currentHp);
	}

	public void GetDamage(float dam)
	{
		currentHp -= dam;

		DOTween.To(x => slider.value = x, slider.value, currentHp / MaxHp, 0.3f).Play();
		OnDamaged.Invoke(currentHp);
		slider.GetComponent<BarShackEvent>().ShackBar();
		if (currentHp <= 0)
		{
			OnDead.Invoke();
		}
	}

}
