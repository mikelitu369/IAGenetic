using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ataque", menuName = "ScriptableObjects/Ataque", order = 1)]
public class Ataque : ScriptableObject
{
    public int coste, minDmg, maxDmg;
    public float pre;

    public float Optimista()
    {
        return maxDmg;
    }

    public float Pesimista()
    {
        return minDmg * pre;
    }

    public float Analitico()
    {
        return (pre * ((maxDmg + minDmg) / 2)) / coste;
    }
}
