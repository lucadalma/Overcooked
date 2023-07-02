using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicettaScript : MonoBehaviour
{

    public string NomeRicetta;

    public Ingrediente[] ingredienti;

    public bool Isdone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chef")) 
        {
            other.GetComponent<AIController>().ricetta = gameObject.GetComponent<RicettaScript>();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

}
