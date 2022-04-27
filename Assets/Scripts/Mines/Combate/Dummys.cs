using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dummys
{
    public static Reglas.ataques Atacar(personalidades personalidad, int energia)
    {
        Reglas.ataques ataque = Reglas.ataques.descanso;
        List<float> probabilidades = new List<float>();
      
        switch (personalidad)
        {
            case personalidades.aleatorio:
                ataque = (Reglas.ataques)Random.Range(0, 4);
                if (Reglas.Coste(ataque) > energia) ataque = Reglas.ataques.descanso;
                return ataque;

            case personalidades.optimista:
                probabilidades = new List<float>();
                probabilidades.Add(Reglas.EvaluacionOptimista(Reglas.ataques.pesado));
                probabilidades.Add(Reglas.EvaluacionOptimista(Reglas.ataques.random));
                probabilidades.Add(Reglas.EvaluacionOptimista(Reglas.ataques.ligero));
                probabilidades.Add(Reglas.EvaluacionOptimista(Reglas.ataques.pesimo));                
                break;

            case personalidades.pesimiista:
                probabilidades = new List<float>();
                probabilidades.Add(Reglas.Evaluacionpesimista(Reglas.ataques.pesado));
                probabilidades.Add(Reglas.Evaluacionpesimista(Reglas.ataques.random));
                probabilidades.Add(Reglas.Evaluacionpesimista(Reglas.ataques.ligero));
                probabilidades.Add(Reglas.Evaluacionpesimista(Reglas.ataques.pesimo));               
                break;

            case personalidades.analitico:
                probabilidades = new List<float>();
                probabilidades.Add(Reglas.EvaluacionAnalitica(Reglas.ataques.pesado));
                probabilidades.Add(Reglas.EvaluacionAnalitica(Reglas.ataques.random));
                probabilidades.Add(Reglas.EvaluacionAnalitica(Reglas.ataques.ligero));
                probabilidades.Add(Reglas.EvaluacionAnalitica(Reglas.ataques.pesimo));
                break;

            case personalidades.optimista_pesimista:
                probabilidades = new List<float>();
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.pesado) + Reglas.Evaluacionpesimista(Reglas.ataques.pesado)) / 2);
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.random) + Reglas.Evaluacionpesimista(Reglas.ataques.random)) / 2);
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.ligero) + Reglas.Evaluacionpesimista(Reglas.ataques.ligero)) / 2);
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.pesimo) + Reglas.Evaluacionpesimista(Reglas.ataques.pesimo)) / 2);
                break;

            case personalidades.optimista_analitico:
                probabilidades = new List<float>();
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.pesado) + Reglas.EvaluacionAnalitica(Reglas.ataques.pesado)) / 2);
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.random) + Reglas.EvaluacionAnalitica(Reglas.ataques.random)) / 2);
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.ligero) + Reglas.EvaluacionAnalitica(Reglas.ataques.ligero)) / 2);
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.pesimo) + Reglas.EvaluacionAnalitica(Reglas.ataques.pesimo)) / 2);
                break;

            case personalidades.pesimista_analitico:
                probabilidades = new List<float>();
                probabilidades.Add((Reglas.Evaluacionpesimista(Reglas.ataques.pesado) + Reglas.EvaluacionAnalitica(Reglas.ataques.pesado)) / 2);
                probabilidades.Add((Reglas.Evaluacionpesimista(Reglas.ataques.random) + Reglas.EvaluacionAnalitica(Reglas.ataques.random)) / 2);
                probabilidades.Add((Reglas.Evaluacionpesimista(Reglas.ataques.ligero) + Reglas.EvaluacionAnalitica(Reglas.ataques.ligero)) / 2);
                probabilidades.Add((Reglas.Evaluacionpesimista(Reglas.ataques.pesimo) + Reglas.EvaluacionAnalitica(Reglas.ataques.pesimo)) / 2);
                break;

            case personalidades.completo:
                probabilidades = new List<float>();
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.pesado) + Reglas.Evaluacionpesimista(Reglas.ataques.pesado) + Reglas.EvaluacionAnalitica(Reglas.ataques.pesado)) / 3);
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.random) + Reglas.Evaluacionpesimista(Reglas.ataques.random) + Reglas.EvaluacionAnalitica(Reglas.ataques.random)) / 3);
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.ligero) + Reglas.Evaluacionpesimista(Reglas.ataques.ligero) + Reglas.EvaluacionAnalitica(Reglas.ataques.ligero)) / 3);
                probabilidades.Add((Reglas.EvaluacionOptimista(Reglas.ataques.pesimo) + Reglas.Evaluacionpesimista(Reglas.ataques.pesimo) + Reglas.EvaluacionAnalitica(Reglas.ataques.pesimo)) / 3);
                break;            
        }
        
        int dado = Random.Range(0, 100);
        int ataqueI = 0;
        for (int i = 0; i < dado; i++)
        {
            //Debug.Log(ataqueI);
            //Debug.Log(probabilidades[ataqueI]);
            if (probabilidades[ataqueI] < 0) ++ataqueI;
            --probabilidades[ataqueI];
        }
        ataque = (Reglas.ataques)ataqueI;
        if (Reglas.Coste(ataque) > energia) ataque = Reglas.ataques.descanso;

        return ataque;
    }
}
