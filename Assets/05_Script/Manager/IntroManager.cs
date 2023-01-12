using DG.Tweening;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private DoEventRoot fadeEvent;
    [SerializeField] private GameObject ui;

    private bool started;

    private void Start()
    {

        Time.timeScale = 1;

        FAED.StopSound("MainBGM");
        FAED.PlaySound("IntroBGM");

    }

    public void StartScene()
    {

        if (started) return;

        started = true;

        ui.transform.DOLocalMoveX(-2000, 1.5f)
            .OnComplete(() =>
            {

                player.GetComponent<Animator>().SetTrigger("Run");
                player.transform.DOMoveX(20, 3f).OnComplete(() =>
                {

                    fadeEvent.Play(() => SceneManager.LoadScene("TestPlay"));

                });

            });

    }

}
