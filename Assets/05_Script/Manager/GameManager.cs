using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [field: SerializeField] public Transform enemyTarget;
    public PlayerCtrl player;

    public static GameManager instance;

    private void Awake()
    {
        
        instance = this;
        player = enemyTarget.GetComponent<PlayerCtrl>();
    }

}
