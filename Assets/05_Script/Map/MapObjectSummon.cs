using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectSummon : MonoBehaviour
{

    [SerializeField] private List<string> mapObjList = new List<string>();
    [SerializeField] private List<string> mapDigainObj = new List<string>();
    [SerializeField] private Transform summonTargetPos;

    public void StartMapObjSummon()
    {

        StartCoroutine(ObjSummonCo());

        for(int i =0; i < 3; i++)
        {

            StartCoroutine(ObjDigainSummonCo());

        }

    }

    IEnumerator ObjSummonCo()
    {

        while (true)
        {

            yield return new WaitForSeconds(Random.Range(3f, 15f));

            FAED.Pop(FAED.Random(mapObjList), summonTargetPos.position, Quaternion.identity);

        }

    }

    IEnumerator ObjDigainSummonCo()
    {

        while (true)
        {

            yield return new WaitForSeconds(Random.Range(1f, 5f));

            FAED.Pop(FAED.Random(mapDigainObj), summonTargetPos.position, Quaternion.identity);

        }

    }

    public void StopSpawn()
    {

        StopAllCoroutines();

    }
}
