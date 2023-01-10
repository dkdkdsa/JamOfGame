using Classs;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingBoss : EnemyRoot
{

    [SerializeField] private Transform summonPos;

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

            for (int i = 0; i <5; i++)
            {

                r -= 20;
                FAED.Pop("SuReGum", transform.position, Quaternion.Euler(new Vector3(0, 0, r))).GetComponent<SuReGum>().SetBullet();

            }

            FAED.InvokeDelay(() =>
            {

                for(int i = 0; i < 2; i++)
                {

                    FAED.Pop("Bat", new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) + (Vector2)summonPos.position, Quaternion.identity);

                }

            }, 0.5f);

            FAED.InvokeDelay(() =>
            {

                for (int i = 0; i < 2; i++)
                {

                    FAED.Pop("Bat", new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) + (Vector2)summonPos.position, Quaternion.identity);

                }

                float r = 60;

                for (int i = 0; i < 5; i++)
                {

                    r -= 20;
                    FAED.Pop("SuReGum", transform.position, Quaternion.Euler(new Vector3(0, 0, r))).GetComponent<SuReGum>().SetBullet();

                }

            }, 1.5f);

        });

    }

}
