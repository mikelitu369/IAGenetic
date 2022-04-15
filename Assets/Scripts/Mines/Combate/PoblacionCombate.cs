using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoblacionCombate : Poblacion
{
    [SerializeField] Text texto;

    public static List<float> ADN_MVP;

    protected override IEnumerator Evaluacion(Sujeto sujeto)
    {
        sujeto.fitnes = Entrenador.Entrenamiento(sujeto.genes);
        yield return null;
    }

    public override void Conclusion()
    {
        texto.text = 100 - ((poblacion[0].fitnes * 100) / Entrenador.entrenamientos) + "%";
        ADN_MVP = poblacion[0].genes;
    }
}
