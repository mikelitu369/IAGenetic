using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoblacionSuma0 : Poblacion
{
    protected override void Evaluacion(Sujeto sujeto)
    {
        float value = 0;
        foreach(float f in sujeto.genes)
        {
            value += f;
        }

        sujeto.fitnes = Mathf.Abs(value);
    }      
}
