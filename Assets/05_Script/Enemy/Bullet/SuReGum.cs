using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuReGum : MonoBehaviour
{

    public void SetBullet()
    {

    }

    private void Update()
    {

        transform.Translate(Vector2.right * 7 * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Player"))
        {

            GameManager.instance.player.hp.GetDamage(10);
            FAED.Push(gameObject);

        }

        if (collision.transform.CompareTag("Wall"))
        {

            FAED.Push(gameObject);

        }

    }

}
