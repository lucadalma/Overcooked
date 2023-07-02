using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRicetta : MonoBehaviour
{
    [SerializeField]
    GameObject[] ricette;

    private GameObject tmp_ricetta;

    public bool canSpawn;
    private void Start()
    {
        canSpawn = true;
    }

    private void Update()
    {
        if (canSpawn) 
        {
            tmp_ricetta = Instantiate(ricette[Random.Range(0,3)], transform.position, Quaternion.identity);
            canSpawn = false;
        }

        if (tmp_ricetta.activeSelf == false) 
        {
            canSpawn = true;
        }

    }

}
