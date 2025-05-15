using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Darwin : MonoBehaviour
{
    public GameObject criatura;
    public Cristura cristuraMuestra;
    public int x, y;
    int generacion = 0;
    public List<Cristura> pueblo = new List<Cristura>();
    public List<float> evaluaciones = new List<float>();

    IEnumerator Start()
    {
        PoblacionInicial();
      while (true)
        {
            Evaluar();

            yield return new WaitForSeconds(0.5f);
            SeleccionNatural();

            yield return new WaitForSeconds(1);
            Repoblar();

            generacion++;
        }
    }

    
    public void PoblacionInicial()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Cristura c =  (Instantiate(criatura, new Vector3(i*2, j*2,0), Quaternion.identity)).GetComponent<Cristura>();
                c.Aleatorizar();
                pueblo.Add(c);
            }
        }
    }

    public void Evaluar()
    {
        evaluaciones.Clear();
        for (int i = 0; i < pueblo.Count; i++)
        {
            evaluaciones.Add(pueblo[i].Comparar(cristuraMuestra.genoma));
        }
    }

    public void SeleccionNatural()
    {
        List<Cristura> elegidos = new List<Cristura>();

        for (int j = 0; j < 5; j++)
        {
            int indice = -1;
            float dMenor = 1000000;
            for (int i = 0; i < pueblo.Count; i++)
            {
                if (evaluaciones[i] < dMenor)
                {
                    dMenor = evaluaciones[i];
                    indice = i;
                }
            }
            elegidos.Add(pueblo[indice]);
            pueblo.RemoveAt(indice);
            evaluaciones.RemoveAt(indice);
        }

        for(int i = 0;i < pueblo.Count;i++)
        {
            Destroy(pueblo[i].gameObject);
        }
        pueblo.Clear();
        evaluaciones.Clear();
        pueblo = elegidos;
    }

    public void Repoblar()
    {
        for(int i = 0; i < x; i++)
        {
            for(int j = 0; j < y; j++)
            {
                if((i*5)+j < 5 && pueblo[i+j] != null)
                {
                    pueblo[i + j].transform.position = new Vector3(i * 2, j * 2, 0);
                }
                else
                {
                    Cristura c = (Instantiate(criatura, new Vector3(i * 2, j * 2, 0), Quaternion.identity)).GetComponent<Cristura>();
                    int p = Random.Range(0, 5);
                    int m = Random.Range(0, 5);
                    c.Parir(pueblo[p].genoma, pueblo[m].genoma);
                    if((i*5)+j > 14)
                    {
                        c.Mutar();
                    }
                    pueblo.Add(c);
                }
            }
        }
    }
}
