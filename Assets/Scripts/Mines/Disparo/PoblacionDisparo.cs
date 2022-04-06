using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoblacionDisparo : Poblacion
{
    [SerializeField] GameObject bullet;

    public GameObject objetivo;

    bool evaluando;

    Sujeto sujetoEvaluar;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        try
        {
            Gizmos.DrawSphere(objetivo.transform.position, Mathf.Sqrt(poblacion[0].fitnes));
        }
        catch { };
    }

    protected override IEnumerator Evaluacion(Sujeto sujeto)
    {
        sujetoEvaluar = sujeto;

        GameObject g = Instantiate(bullet, transform);
        Bullet b = g.GetComponent<Bullet>();

        evaluando = true;

        b.Shoot(sujeto.genes, this);
        
        while(evaluando) yield return null;
    }

    public void ResultadoEvaluacion(float resultado)
    {
        sujetoEvaluar.fitnes = resultado;
        evaluando = false;
    }
}
