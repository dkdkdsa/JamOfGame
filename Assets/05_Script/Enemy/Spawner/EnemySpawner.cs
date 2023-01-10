using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classs;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private List<string> groundEnemyList = new List<string>();
    [SerializeField] private List<string> skyEnemyList = new List<string>();
    [SerializeField] private List<BossSummonList> bossList = new List<BossSummonList>();
    [SerializeField] private Transform basePos;

    private void Start()
    {
        
        SummonStart();

    }

    public void SummonStart()
    {

        StartCoroutine(StartSummonGround());
        StartCoroutine(StartSummonSky());

    }

    public void BossSummon()
    {

        //보스 소환 경고

        StopAllCoroutines();

        FindObjectsOfType<EnemyRoot>().ToList().ForEach(x => FAED.Push(x.gameObject));

        var summoningBoss = FAED.Random(bossList);

        FAED.Pop(summoningBoss.bossKey, summoningBoss.summonPos.position, Quaternion.identity);

    }

    IEnumerator StartSummonGround()
    {

        while (true)
        {

            FAED.Pop(FAED.Random(groundEnemyList), new Vector3(basePos.transform.position.x, Random.Range(-3f, -2.8f)), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5f, 8f));

        }

    }

    IEnumerator StartSummonSky()
    {

        while (true)
        {

            FAED.Pop(FAED.Random(skyEnemyList), new Vector3(basePos.transform.position.x, Random.Range(1f, 5f)), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f, 5f));

        }

    }

}
