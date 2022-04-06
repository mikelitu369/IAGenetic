using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Poblacion : MonoBehaviour
{
    protected class Sujeto
    {
        public List<float> genes = new List<float>();
        public float fitnes = float.MaxValue;

        public Sujeto(int tama�o)
        {
            for (int i = 0; i < tama�o; i++)
            {
                genes.Add(Random.Range(minGenetic, maxGenetic));
            }
        }

        public Sujeto(List<float> genetica)
        {
            foreach (float f in genetica)
            {
                genes.Add(f);
            }
        }

        public static int Compare(Sujeto a, Sujeto b)
        {
            if (a.fitnes > b.fitnes) return 1;
            if (a.fitnes < b.fitnes) return -1;
            return 0;
        }
    }

    protected List<Sujeto> poblacion = new List<Sujeto>();

    [SerializeField] int tama�oSujetos;
    [SerializeField] int poblacionInicial, numeroDescendencia;
    [SerializeField] float probabilidadMutacion;


    [SerializeField] float minValueGenetic, maxValueGenetic, timeScale, fitnesObjetive;

    public static float minGenetic, maxGenetic;

    int generacion = 0;

    float timeStart;

    protected abstract IEnumerator Evaluacion(Sujeto sujeto);

    private void Start()
    {
        Time.timeScale = timeScale;
        minGenetic = minValueGenetic;
        maxGenetic = maxValueGenetic;
        timeStart = Time.time;
        StartCoroutine(RealStart());
    }

    private IEnumerator RealStart()
    {
        for (int i = 0; i < poblacionInicial; i++)
        {
            poblacion.Add(new Sujeto(tama�oSujetos));
        }
        foreach(Sujeto s in poblacion)
        {
            yield return Evaluacion(s);
        }
        OrdenarPoblacion();
        StartCoroutine(Generacion());
    }

    IEnumerator OrdenarPoblacion()
    {
        foreach(Sujeto s in poblacion)
        {
            if (s.fitnes == float.MaxValue) yield return Evaluacion(s);
        }
        poblacion.Sort(Sujeto.Compare);
    }

    IEnumerator Generacion()
    {
        ++generacion;

        //Seleccion de los progenitores
        Sujeto madre = poblacion[0], padre = poblacion[1];

        //Generacion de descendencia
        List<List<float>> genesDescendencia = Genetica.Cruce(madre.genes, padre.genes, numeroDescendencia);
        List<Sujeto> descendencia = new List<Sujeto>();
        foreach (List<float> genes in genesDescendencia)
        {
            descendencia.Add(new Sujeto(genes));
        }

        //Remplazo generacional
        for (int i = 0; i < descendencia.Count; i++)
        {
            poblacion.RemoveAt(poblacion.Count - 1);
        }
        for (int i = 0; i < descendencia.Count; i++)
        {
            poblacion.Add(descendencia[i]);
        }
        yield return OrdenarPoblacion();

        //Mutaciones
        if (Random.Range(0, 100) < probabilidadMutacion)
        {
            int afortunado = Random.Range(0, poblacion.Count);
            List<float> nuevosGenes = Genetica.Mutar(poblacion[afortunado].genes);
            poblacion.RemoveAt(afortunado);
            poblacion.Add(new Sujeto(nuevosGenes));
            yield return OrdenarPoblacion();
        }

        //Analisis resultados
        string genesString = "[" + poblacion[0].genes[0].ToString("F0") + ", " + poblacion[0].genes[1].ToString("F0") + ", " + poblacion[0].genes[2].ToString("F0") + ", " + poblacion[0].genes[3].ToString("F0") + ", " + poblacion[0].genes[4].ToString("F0") + "]";
        print("Generacion: " + generacion + "  ||  MejorCandidato: " + (100 - ((poblacion[0].fitnes * 100) / Entrenador.entrenamientos)) + "%  ||  Tiempo: " + (Time.time - timeStart).ToString("F2") + " || " + genesString);

        if (poblacion[0].fitnes > fitnesObjetive) StartCoroutine(Generacion());
    }
}
