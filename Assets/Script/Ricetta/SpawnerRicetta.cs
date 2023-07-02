using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRicetta : MonoBehaviour
{
    [SerializeField]
    GameObject[] ricette;

    public bool canSpawn;
    private void Start()
    {
        canSpawn = true;
    }

    private void Update()
    {
        if (canSpawn) 
        {
            Instantiate(ricette[Random.Range(0,3)], transform.position, Quaternion.identity);
            canSpawn = false;
        }
    }

}
