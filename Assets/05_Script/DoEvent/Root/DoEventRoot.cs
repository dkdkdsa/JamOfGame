using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class DoEventRoot : MonoBehaviour
{

    public abstract void Play(UnityAction endAction);

}
