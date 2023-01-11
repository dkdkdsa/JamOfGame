using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;

public class DoFadeEvent : DoEventRoot
{

    [SerializeField] private Image fadeImage;

    public override void Play(UnityAction endAction)
    {

        fadeImage.DOFade(1, 0.5f).OnComplete(() => endAction?.Invoke());

    }

}
