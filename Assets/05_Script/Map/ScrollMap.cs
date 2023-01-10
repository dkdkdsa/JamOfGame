using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMap : MonoBehaviour
{

    [SerializeField] private float speed;

    private void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x < -44)
        {

            transform.position = new Vector2(22, 0);

        }

    }

}
