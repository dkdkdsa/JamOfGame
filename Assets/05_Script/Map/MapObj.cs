using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObj : MonoBehaviour
{

    [SerializeField] private float speed;

    private void Update()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -22)
        {

            FAED.Push(gameObject);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Player"))
        {

            GameManager.instance.player.hp.GetDamage(15);
            FAED.Push(gameObject);

        }

    }

}
