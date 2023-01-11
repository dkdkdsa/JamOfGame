using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour
{

    [SerializeField] private DoEventRoot fadeEvent;

    public void Fade(string sceneName)
    {

        fadeEvent.Play(() => SceneManager.LoadScene(sceneName));

    }

    public void Exit()
    {

        Application.Quit();

    }

    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }

}
