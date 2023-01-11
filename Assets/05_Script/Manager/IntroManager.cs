using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    private void Start()
    {

        FAED.StopSound("MainBGM");
        FAED.PlaySound("IntroBGM");

    }

}
