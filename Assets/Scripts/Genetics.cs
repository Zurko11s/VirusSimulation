using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genetics : MonoBehaviour
{
    public GameObject creature;
    public int x , y;
    public Creatura sample;
    public List<Creatura> creaturaList = new List<Creatura>();
    public List<float> Evaluations = new List<float>();

    void Start()
    {
        firstPopulation();
    }

    public void firstPopulation()
    {
        for(int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Creatura c = Instantiate(creature, new Vector3(i*2, j*2, 0), Quaternion.identity).GetComponent<Creatura>();
                c.Randomizer();
                creaturaList.Add(c);
            }
        }
    }

    public void Evaluate()
    {
        Evaluations.Clear();
        for(int i = 0; i < creaturaList.Count; i++)
        {

        }
    }
}
