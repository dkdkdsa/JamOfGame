using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuReGum : MonoBehaviour
{

    public void SetBullet()
    {

        FAED.InvokeDelay(() =>
        {

            FAED.Push(gameObject);

        }, 4f);

    }

    private void Update()
    {

        transform.Translate(Vector2.right * 7 * Time.deltaTime);

    }

}
