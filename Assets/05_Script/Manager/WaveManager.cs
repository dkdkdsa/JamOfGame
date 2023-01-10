using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private DoWaringEvent clearEvent;

    private EnemySpawner spawner;
    private MapObjectSummon mapSummoner;

    public int clearCount = 1;

    private void Awake()
    {
        
        spawner = FindObjectOfType<EnemySpawner>();
        mapSummoner = FindObjectOfType<MapObjectSummon>();

    }

    private void Start()
    {

        //이쪽에 튜토리얼

    }

    public void WaveManaging()
    {

        FindObjectOfType<EnemySpawner>().SummonStart();
        FindObjectOfType<MapObjectSummon>().StartMapObjSummon();
        StartCoroutine(WaveCo());

    }

    public void ClearWave()
    {

        clearEvent.Play(() =>
        {

            GameManager.instance.shop.gameObject.SetActive(true);
            GameManager.instance.shop.OpenShop();

        });

        mapSummoner.StopSpawn();

    }

    IEnumerator WaveCo()
    {

        yield return new WaitForSeconds(100f);

        spawner.BossSummon();

    }

}
