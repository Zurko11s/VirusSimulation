using UnityEngine;

public class Cristura : MonoBehaviour
{
    SpriteRenderer spr;
    
    public Vector3 escala;
    public Color color;
    public float Speed;
    public int ingestedfood;

    public float[] genoma;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        CrearGenoma();
    }

    public void CrearGenoma()
    {
        genoma = new float[6];
        genoma[0] = color.r;
        genoma[1] = color.g;
        genoma[2] = color.b;
        genoma[3] = escala.x;
        genoma[4] = escala.y;
        genoma[5] = escala.z;
    }

    [ContextMenu("Aleatorizar ya mismo!")]
    public void Aleatorizar()
    {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        escala = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), 1);
        Visualizar();
    }


    public void Visualizar()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = color;
        transform.localScale = escala;
    }

    public float Comparar(float[] genomaEnemigo)
    {
        CrearGenoma();
        float[] diferencia = new float[6];
        for (int i = 0; i < 6; i++)
        {
            diferencia[i] = genomaEnemigo[i] - genoma[i];
        }
        float resultado = 0f;

        for (int i = 0; i < 6; i++)
        {
            resultado += diferencia[i]* diferencia[i];
        }

        resultado = Mathf.Sqrt(resultado);

        return resultado;

    }


    public void Mutar()
    {
        CrearGenoma();
        genoma[Random.Range(0, 3)] = Random.Range(0f, 1f);
        genoma[Random.Range(3, 5)] = Random.Range(0.5f, 1.5f);
        color = new Color(genoma[0], genoma[1], genoma[2]);
        escala = new Vector3(genoma[3], genoma[4], genoma[5]);
        Visualizar();
    }

    public void Parir(float[] padre, float[] madre)
    {
        if(Random.Range(0,100) < 50)
        {
            color = new Color(padre[0], padre[1], padre[2]);
            escala = new Vector3(madre[3], madre[4], madre[5]);
        } else
        {
            color = new Color(madre[0], madre[1], madre[2]);
            escala = new Vector3(padre[3], padre[4], padre[5]);
        }
        CrearGenoma();
        Visualizar();
    }
}
