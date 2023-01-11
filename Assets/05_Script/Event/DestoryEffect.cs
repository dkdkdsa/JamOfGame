using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEffect : MonoBehaviour
{
    
    public void Die()
    {

        FAED.Push(gameObject);

    }

}
