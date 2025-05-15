using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Creatura : MonoBehaviour
{
    SpriteRenderer spr;
    public Color color = Color.white;
    public Vector3 scale;
    public float[] genome;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    
    public void CreateGenome()
    {
        genome = new float[6];
        genome[0] = color.r;
        genome[1] = color.g;
        genome[2] = color.b;
        genome[3] = scale.x;
        genome[4] = scale.y;
        genome[5] = scale.z;
    }


    [ContextMenu("Randomize ts")]
    public void Randomizer()
    {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        scale = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), 1);
        
    }

    public void Visual()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = color;
        transform.localScale = scale;
    }

    public float Compare(float[] genomeEnemy)
    {
        CreateGenome();
        float[] difference = new float[6];
        for(int i = 0; i < 6; i++)
        {
            difference[i] = genomeEnemy[i] - genome[i];
        }

        float result = 0f;

        for (int i = 0; i < 6; i++)
        {
           result  += difference[i] * difference[i];
        }

        result = Mathf.Sqrt(result);

        return result;
    }

    public void Mutate()
    {
        CreateGenome();
        genome[Random.Range(0, 3)] = Random.Range(0f, 1f);
        genome[Random.Range(3,6)] = Random.Range(0.5f, 1.5f);
        color = new Color(genome[0], genome[1], genome[2]);
        scale = new Vector3(genome[4], genome[5], genome[6]);
    }
}
