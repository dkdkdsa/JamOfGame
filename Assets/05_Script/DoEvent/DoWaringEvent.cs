using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoWaringEvent : DoEventRoot
{

    [SerializeField] private GameObject upImage;
    [SerializeField] private GameObject downImage;
    [SerializeField] private GameObject wringText;
    [SerializeField] private GameObject canvasZeroPos;

    public override void Play(UnityAction endAction)
    {

        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(wringText.transform.DOMoveX(canvasZeroPos.transform.position.x, 0.5f))
            .Join(upImage.transform.DOMoveY(canvasZeroPos.transform.position.y - ((1080 / 2) + 100), 0.5f))
            .Join(downImage.transform.DOMoveY(canvasZeroPos.transform.position.y + ((1080 / 2) + 100), 0.5f))
            .AppendInterval(3f)
            .Append(wringText.transform.DOMoveX(-2000, 0.5f))
            .Join(upImage.transform.DOLocalMoveY(800f, 0.5f))
            .Join(downImage.transform.DOLocalMoveY(-800f, 0.5f))
            .OnComplete(() =>
            {

                endAction?.Invoke();

            });

    }

}
