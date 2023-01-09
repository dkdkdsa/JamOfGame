using Classs;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullHead : EnemyRoot
{

    public override void Chase()
    {

        Vector3 dir = target.transform.position - transform.position;

        dir.Normalize();

        rigid.velocity = dir * speed;

        int n = Random.Range(0, 101);

        if(n == 100 && !attackCoolDown)
        {

            ChangeAIState("Attack");

        }

    }

    public override void Attack()
    {

        base.Attack();

        StartEnemyAttack(() =>
        {

            FAED.Pop("EnemyBullet", transform.position, Quaternion.identity).GetComponent<EnemyBullet>().SetBullet(target);

        });

    }

}
