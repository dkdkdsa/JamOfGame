using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;

    private Rigidbody2D rb;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    public void SetBullet(Transform target)
    {

        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        rb.velocity = dir * bulletSpeed;

        FAED.InvokeDelay(() => FAED.Push(gameObject), 5f);

    }

}
