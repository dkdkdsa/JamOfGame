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
    public GameObject exitObj;
    public GameObject waveObj;

    public static GameManager instance;

    private void Awake()
    {
        
        instance = this;
        //saveData = FAED.Load<SaveData>(Application.dataPath, "Data");
        player = enemyTarget.GetComponent<PlayerCtrl>();
        waveManager = FindObjectOfType<WaveManager>();
        shakeManager = FindObjectOfType<CameraShakeManager>();
        walletManager = FindObjectOfType<WalletManager>();
        descPanel = FindObjectOfType<DescPanelManager>();
    }

    private void Start()
    {

        FAED.StopSound("IntroBGM");
        FAED.PlaySound("MainBGM");

        if (PlayerPrefs.GetInt("Start") != 1)
        {

            Time.timeScale = 0;
            ttrlObj.gameObject.SetActive(true);
            waveObj.SetActive(false);
            exitObj.SetActive(false);
            saveData.isFirst = true;
            PlayerPrefs.SetInt("Start", 1);

        }
        else
        {

            waveObj.SetActive(true);
            exitObj.SetActive(true);
            shop.OpenShop();

        }

    }

    public void ResetTimeScale()
    {

        Time.timeScale = 1;

    }

    public void SetTimeScale()
    {

        Time.timeScale = 0;

    }


}
