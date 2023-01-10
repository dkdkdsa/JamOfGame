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

}
