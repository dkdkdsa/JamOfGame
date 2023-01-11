using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [field: SerializeField] public Transform enemyTarget;

    public Shopper shop;
    public WaveManager waveManager;
    public PlayerCtrl player;
    public SaveData saveData;
    public GameObject ttrlObj;
    public CameraShakeManager shakeManager;
    public Slider bossSlider;
    public WalletManager walletManager;
    public DescPanelManager descPanel;

    public static GameManager instance;

    private void Awake()
    {
        
        instance = this;
        saveData = FAED.Load<SaveData>(Application.dataPath, "Data");
        player = enemyTarget.GetComponent<PlayerCtrl>();
        waveManager = FindObjectOfType<WaveManager>();
        shakeManager = FindObjectOfType<CameraShakeManager>();
        walletManager = FindObjectOfType<WalletManager>();
        descPanel = FindObjectOfType<DescPanelManager>();
    }

    private void Start()
    {

        if (saveData.isFirst == false)
        {

            Time.timeScale = 0;
            ttrlObj.gameObject.SetActive(true);
            saveData.isFirst = true;
            FAED.Save(saveData, Application.dataPath, "Data");

        }
        else
        {

            shop.OpenShop();

        }

    }

    public void ResetTimeScale()
    {

        Time.timeScale = 1;

    }


}
