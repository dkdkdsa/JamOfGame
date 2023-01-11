using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [field: SerializeField] public Transform enemyTarget;

    public Shopper shop;
    public WaveManager waveManager;
    public PlayerCtrl player;
    public SaveData saveData;
    public GameObject ttrlObj;
    public CameraShakeManager shakeManager;
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

    private void OnDisable()
    {

        FAED.Save(saveData, Application.dataPath, "Data");

    }

}
