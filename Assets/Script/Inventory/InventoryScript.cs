using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Ingrediente
{
    public string IngridientName;

    public int Quantity;
}

public class InventoryScript : MonoBehaviour
{
    public Ingrediente ingrediente1;

    public Ingrediente ingrediente2;

    public Ingrediente ingrediente3;

}
