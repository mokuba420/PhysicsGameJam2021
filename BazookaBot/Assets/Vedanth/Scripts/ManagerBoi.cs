using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBoi : MonoBehaviour
{
    public GameObject partiExplosion, partiSpark, partiDust, partiSmoke, partiFire, partiPuff;
    public GameObject Rocket;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
