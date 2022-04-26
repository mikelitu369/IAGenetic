using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Entrenador
{
    public static int entrenamientos = 1000;

    public static float Entrenamiento(List<float> genes)
    {
        Individuo pupilo = new Individuo(genes);
        int derrotas = 0;

        for (int i = 0; i < entrenamientos; i++)
        {
            if (!Combate(pupilo, (personalidades)Random.Range(0,8))) ++derrotas;
        }

        return derrotas;
    }

    static bool Combate(Individuo pupilo, personalidades dummy)
    {
        int vidaPupilo = 200, vidaDummy = 200;
        int energiaPupilo = 10, energiaDummy = 10;

        bool pupiloTurn = true;

        while (vidaPupilo > 0 && vidaDummy > 0)
        {
            if (pupiloTurn)
            {
                Reglas.ataques ataque = pupilo.SeleccionarAtaque(energiaPupilo);

                if (ataque == Reglas.ataques.descanso) energiaPupilo = 10;
                else
                {
                    vidaDummy -= Reglas.Atacar(ataque);
                    energiaPupilo -= Reglas.Coste(ataque);
                }
            }
            else
            {
                Reglas.ataques ataque = Dummys.Atacar(dummy, energiaDummy);

                if (Reglas.Coste(ataque) > energiaDummy || ataque == Reglas.ataques.descanso) energiaDummy = 10;
                else
                {
                    vidaPupilo -= Reglas.Atacar(ataque);
                    energiaDummy -= Reglas.Coste(ataque);
                }
            }
            pupiloTurn = !pupiloTurn;
        }

        if (vidaPupilo <= 0) return false;
        else return true;
    }
}
