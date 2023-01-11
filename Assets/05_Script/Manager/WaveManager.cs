using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private DoWaringEvent clearEvent;
    [SerializeField] private TextMeshProUGUI text;

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

        //���ʿ� Ʃ�丮��

        text.text = $"�ĵ� : {clearCount}";

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

        clearCount++;

        text.text = $"�ĵ� : {clearCount}";

        mapSummoner.StopSpawn();

    }

    IEnumerator WaveCo()
    {

        yield return new WaitForSeconds(3f);

        spawner.BossSummon();

    }

}
