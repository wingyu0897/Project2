using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreTypeMiningTime : MonoBehaviour
{
    [SerializeField]
    float rock = 100;
    [SerializeField]
    float iron = 80;
    [SerializeField]
    float coal = 90;
    [SerializeField]
    float cupper = 90;

    public float Oretypeminingtime(string oreType)
    {
        if (oreType == "Stone")
        {
            return rock / 100;
        }
        else if (oreType == "Iron")
        {
            return iron / 100;
        }
        else if (oreType == "Coal")
        {
            return coal / 100;
        }
        else if (oreType == "Cupper")
        {
            return cupper / 100;
        }
        return 1;
    }
}
