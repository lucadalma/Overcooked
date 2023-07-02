using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarileScript : MonoBehaviour
{
    public bool Ingrediente1;

    public bool Ingrediente2;

    public bool Ingrediente3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chef")) 
        {
            if (Ingrediente1) 
            {
                other.GetComponent<InventoryScript>().ingrediente1.Quantity = 5;
            }
            else if (Ingrediente2)
            {
                other.GetComponent<InventoryScript>().ingrediente2.Quantity = 5;
            }
            else if (Ingrediente3)
            {
                other.GetComponent<InventoryScript>().ingrediente3.Quantity = 5;
            }
        }
    }
}
