using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individuo
{
    float improvisador, adaptable, optimista, pesimista, analitico;

    public Individuo(List<float> genes)
    {
        improvisador = genes[0];
        adaptable = genes[1];
        optimista = genes[2];
        pesimista = genes[3];
        analitico = genes[4];
    }

    public Reglas.ataques SeleccionarAtaque(int energia)
    {
        if(Random.Range(0,100) < improvisador) return (Reglas.ataques) Random.Range(0, 4);

        float[] opciones = new float[4];

        for (int i = 0; i < 4; i++)
        {
            opciones[i] =   Reglas.EvaluacionOptimista((Reglas.ataques)i) * (int)optimista +
                            Reglas.Evaluacionpesimista((Reglas.ataques)i) * (int)pesimista +
                            Reglas.EvaluacionAnalitica((Reglas.ataques)i) * (int)analitico;
        }

        List<float> opcionesSinOrdenar = new List<float>(opciones);
        List<float> opcionesOrdenadas = new List<float>(opciones);
        opcionesOrdenadas.Sort();

        for (int i = 3; i >= 0; i--)
        {
            if (Reglas.Coste((Reglas.ataques)opcionesSinOrdenar.IndexOf(opcionesOrdenadas[i])) <= energia) return (Reglas.ataques)opcionesSinOrdenar.IndexOf(opcionesOrdenadas[i]);
            else if (Random.Range(0, 100) > adaptable) return Reglas.ataques.descanso;            
        }

        return Reglas.ataques.descanso;
    }
}
