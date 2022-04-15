using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Reglas
{
    public enum ataques
    {
        pesado,
        random,
        ligero,
        pesimo,
        descanso,
    }

    public static int Atacar(ataques ataque)
    {
        switch (ataque)
        {
            case ataques.pesado: return AtaquePesado();
            case ataques.random: return AtaqueRandom();
            case ataques.ligero: return AtaqueLigero();
            case ataques.pesimo: return AtaquePesimo();
            default: return 0;
        }        
    }

    public static int Coste(ataques ataque)
    {
        switch (ataque)
        {
            case ataques.pesado: return 5;
            case ataques.random: return 3;
            case ataques.ligero: return 2;
            case ataques.pesimo: return 2;
            default: return 0;
        }
    }

    public static int EvaluacionOptimista(ataques ataque)
    {
        switch (ataque)
        {
            case ataques.pesado: return 35;
            case ataques.random: return 35;
            case ataques.ligero: return 18;
            case ataques.pesimo: return 12;
            default: return 0;
        }
    }

    public static int Evaluacionpesimista(ataques ataque)
    {
        switch (ataque)
        {
            case ataques.pesado: return 50;
            case ataques.random: return 12;
            case ataques.ligero: return 26;
            case ataques.pesimo: return 12;
            default: return 0;
        }
    }

    public static int EvaluacionAnalitica(ataques ataque)
    {
        switch (ataque)
        {
            case ataques.pesado: return 18;
            case ataques.random: return 21;
            case ataques.ligero: return 43;
            case ataques.pesimo: return 18;
            default: return 0;
        }
    }

    static int AtaquePesado()
    {
        if (Random.Range(0f, 1f) > 0.5f) return 0;
        else return Random.Range(40, 61);
    }

    static int AtaqueRandom()
    {
        if (Random.Range(0f, 1f) > 0.2f) return 0;
        else return Random.Range(20, 61);
    }

    static int AtaqueLigero()
    {
        if (Random.Range(0f, 1f) > 0.7f) return 0;
        else return Random.Range(20, 31);
    }

    static int AtaquePesimo()
    {
        if (Random.Range(0f, 1f) > 0.5f) return 0;
        else return Random.Range(10, 21);
    }    
}
