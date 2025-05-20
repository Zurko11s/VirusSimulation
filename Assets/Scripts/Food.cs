using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Cristura Consumidor;
    private void OnTriggerEnter(Collider other)
    {
        Consumidor.ingestedfood++;
    }
}
