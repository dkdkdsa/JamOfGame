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

        //���ʿ� Ʃ�丮��

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

            //���⿡ ����

        });

        mapSummoner.StopSpawn();

    }

    IEnumerator WaveCo()
    {

        yield return new WaitForSecondsRealtime(3f);

        spawner.BossSummon();

    }

}
