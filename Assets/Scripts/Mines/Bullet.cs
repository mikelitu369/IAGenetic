using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PoblacionDisparo padre;

    public void Shoot(List<float> genes, PoblacionDisparo refenrence)
    {
        padre = refenrence;

        Rigidbody rg = GetComponent<Rigidbody>();

        Vector3 forcedirection = new Vector3(genes[0], genes[1], genes[2]);

        forcedirection = forcedirection.normalized;

        forcedirection *= genes[3];

        rg.AddForce(forcedirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        float distance = (padre.objetivo.transform.position - transform.position).sqrMagnitude;

        padre.ResultadoEvaluacion(distance);

        Destroy(this.gameObject);
    }
}
