using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarShackEvent : MonoBehaviour
{

    private bool isShacking = false;

    public void ShackBar()
    {

        if (isShacking) return;

        isShacking = true;

        transform.DOShakePosition(0.5f, 2, 10, 0)
            .OnComplete(() =>
            {

                isShacking = false;

            });

    }

}
