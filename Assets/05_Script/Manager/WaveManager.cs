using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private DoWaringEvent clearEvent;

    private EnemySpawner spawner;
    private MapObjectSummon mapSummoner;

    private void Awake()
    {
        
        spawner = FindObjectOfType<EnemySpawner>();
        mapSummoner = FindObjectOfType<MapObjectSummon>();

    }

    private void Start()
    {

        //이쪽에 튜토리얼

        WaveManaging();

    }

    private void WaveManaging()
    {

        StartCoroutine(WaveCo());

    }

    public void ClearWave()
    {

        clearEvent.Play(() =>
        {

            //여기에 상점

        });

        mapSummoner.StopSpawn();

    }

    IEnumerator WaveCo()
    {

        yield return new WaitForSecondsRealtime(3f);

        spawner.BossSummon();

    }

}
