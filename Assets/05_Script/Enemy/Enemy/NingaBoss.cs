using Classs;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NingaBoss : EnemyRoot
{
    public override void Chase()
    {

        int n = Random.Range(0, 101);

        if (n == 100 && !attackCoolDown)
        {

            ChangeAIState("Attack");

        }

    }

    public override void Attack()
    {

        base.Attack();

        StartEnemyAttack(() =>
        {

            float r = 60;

            for(int i = 0; i < 55; i++)
            {

                r -= 20;
                FAED.Pop("SuReGum", transform.position, Quaternion.Euler(new Vector3(0, 0, r))).GetComponent<SuReGum>().SetBullet();

            }

            FAED.InvokeDelay(() =>
            {

                float r = 60;

                for (int i = 0; i < 5; i++)
                {

                    r -= 20;
                    FAED.Pop("SuReGum", transform.position, Quaternion.Euler(new Vector3(0, 0, r))).GetComponent<SuReGum>().SetBullet();

                }

            }, 0.9f);

        });

    }

}
