using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoblacionCombate : Poblacion
{
    protected override IEnumerator Evaluacion(Sujeto sujeto)
    {
        sujeto.fitnes = Entrenador.Entrenamiento(sujeto.genes);
        yield return null;
    }
}
