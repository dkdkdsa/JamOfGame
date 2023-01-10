using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    private EnemySpawner spawner;
    private MapObjectSummon mapSummoner;

    private void Awake()
    {
        
        spawner = FindObjectOfType<EnemySpawner>();
        mapSummoner = FindObjectOfType<MapObjectSummon>();

    }

    private void Start()
    {

        //���ʿ� Ʃ�丮��

        WaveManaging();

    }

    private void WaveManaging()
    {

        StartCoroutine(WaveCo());

    }

    public void ClearWave()
    {

        //Ŭ���� UI
        mapSummoner.StopSpawn();

    }

    IEnumerator WaveCo()
    {

        yield return new WaitForSecondsRealtime(3);

        spawner.BossSummon();

    }

}
