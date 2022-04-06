using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Genetica
{
    const float MARGEN = 10f;

    public static List<List<float>> Cruce(List<float> madre, List<float> padre, int numHijos = 2)
    {
        if (madre.Count != padre.Count)
        {
            Debug.LogError("Cruce entre sujetos no semejantes");
            return null;
        }

        List<List<float>> hijos = new List<List<float>>();

        for (int j = 0; j < numHijos; j++)
        {
            List<float> hijo = new List<float>();

            for (int i = 0; i < madre.Count; i++)
            {
                float margen = Mathf.Max(madre[i], padre[i]) / MARGEN;
                float valor = Mathf.Clamp(Random.Range(Mathf.Min(madre[i], padre[i]) - margen, Mathf.Max(madre[i], padre[i]) + margen), Poblacion.minGenetic, Poblacion.maxGenetic);
                hijo.Add(valor);
            }

            hijos.Add(hijo);
        }

        return hijos;
    }

    public static List<float> Mutar(List<float> sujeto)
    {
        float max = float.MinValue, min = float.MaxValue, margen;
        foreach(float f in sujeto)
        {
            max = Mathf.Max(max, f);
            min = Mathf.Min(min, f);
        }
        margen = max / MARGEN;

        sujeto[Random.Range(0, sujeto.Count)] = Mathf.Clamp(Random.Range(min - margen, max + margen), Poblacion.minGenetic, Poblacion.maxGenetic);
        return sujeto;
    }
}
