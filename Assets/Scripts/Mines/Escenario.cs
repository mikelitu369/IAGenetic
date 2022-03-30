using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escenario : MonoBehaviour
{
    [SerializeField] GameObject objetivo, posicionSuperior, posicionInferior;
    [SerializeField] List<GameObject> obstaculos;
    [SerializeField] bool obstaculosRandom;

    private void Start()
    {
        float x = Random.Range(posicionInferior.transform.position.x, posicionSuperior.transform.position.x);
        float y = Random.Range(posicionInferior.transform.position.y, posicionSuperior.transform.position.y);
        float z = Random.Range(posicionInferior.transform.position.z, posicionSuperior.transform.position.z);

        objetivo.transform.position = new Vector3(x, y, z);

        if (obstaculosRandom)
        {
            foreach (GameObject g in obstaculos) g.SetActive(false);
            obstaculos[Random.Range(0, obstaculos.Count)].SetActive(true);
        }
    }
}
