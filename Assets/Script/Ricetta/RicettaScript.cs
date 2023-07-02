using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicettaScript : MonoBehaviour
{

    public string NomeRicetta;

    public string[] listaIngredienti;

    public bool Isdone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chef")) 
        {
            other.GetComponent<AIController>().ricetta = gameObject.GetComponent<RicettaScript>();
        }
    }

}
