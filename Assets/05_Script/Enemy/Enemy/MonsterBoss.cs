using Classs;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss : EnemyRoot
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

            for(int i = 0; i < 3; i++)
            {

                FAED.Pop("Bat", new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) + (Vector2)summonPos.position, Quaternion.identity);

            }

        });

    }

}
