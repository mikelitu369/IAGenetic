using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Reglas
{
    static Ataque pesado, random, ligero, pesimo;
    static bool charge;

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
        Charge();

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
        Charge();

        switch (ataque)
        {
            case ataques.pesado: return pesado.coste;
            case ataques.random: return random.coste;
            case ataques.ligero: return ligero.coste;
            case ataques.pesimo: return pesimo.coste;
            default: return 0;
        }
    }

    public static float EvaluacionOptimista(ataques ataque)
    {
        Charge();

        float divisor = pesado.Optimista() + random.Optimista() + ligero.Optimista() + pesimo.Optimista();
        divisor /= 100f;

        switch (ataque)
        {
            case ataques.pesado: return pesado.Optimista() / divisor;
            case ataques.random: return random.Optimista() / divisor;
            case ataques.ligero: return ligero.Optimista() / divisor;
            case ataques.pesimo: return pesimo.Optimista() / divisor;
            default: return 0;
        }
    }

    public static float Evaluacionpesimista(ataques ataque)
    {
        Charge();

        float divisor = pesado.Pesimista() + random.Pesimista() + ligero.Pesimista() + pesimo.Pesimista();
        divisor /= 100f;

        switch (ataque)
        {
            case ataques.pesado: return pesado.Pesimista() / divisor;
            case ataques.random: return random.Pesimista() / divisor;
            case ataques.ligero: return ligero.Pesimista() / divisor;
            case ataques.pesimo: return pesimo.Pesimista() / divisor;
            default: return 0;
        }
    }

    public static float EvaluacionAnalitica(ataques ataque)
    {
        Charge();

        float divisor = pesado.Analitico() + random.Analitico() + ligero.Analitico() + pesimo.Analitico();
        divisor /= 100f;

        switch (ataque)
        {
            case ataques.pesado: return pesado.Analitico() / divisor;
            case ataques.random: return random.Analitico() / divisor;
            case ataques.ligero: return ligero.Analitico() / divisor;
            case ataques.pesimo: return pesimo.Analitico() / divisor;
            default: return 0;
        }
    }

    static int AtaquePesado()
    {
        Charge();

        if (Random.Range(0f, 1f) > pesado.pre) return 0;
        else return Random.Range(pesado.minDmg, pesado.maxDmg);
    }

    static int AtaqueRandom()
    {
        Charge();

        if (Random.Range(0f, 1f) > random.pre) return 0;
        else return Random.Range(random.minDmg, random.maxDmg);
    }

    static int AtaqueLigero()
    {
        Charge();

        if (Random.Range(0f, 1f) > ligero.pre) return 0;
        else return Random.Range(ligero.maxDmg, ligero.minDmg);
    }

    static int AtaquePesimo()
    {
        Charge();

        if (Random.Range(0f, 1f) > pesimo.pre) return 0;
        else return Random.Range(pesimo.minDmg, pesimo.maxDmg);
    }

    static void Charge()
    {
        if (charge) return;
        pesado = Resources.Load<Ataque>("pesado");
        random = Resources.Load<Ataque>("random");
        ligero = Resources.Load<Ataque>("ligero");
        pesimo = Resources.Load<Ataque>("pesimo");
        charge = true;
    }
}

public enum personalidades
{
    aleatorio,
    optimista,
    pesimiista,
    analitico,
    optimista_pesimista,
    optimista_analitico,
    pesimista_analitico,
    completo
}
