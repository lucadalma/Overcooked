using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    AIController AI;

    [SerializeField]
    GameObject RicettaCanvas;

    [SerializeField]
    GameObject InventoryCanvas;

    [SerializeField]
    TextMeshProUGUI NomeRicetta;
    [SerializeField]
    TextMeshProUGUI Ingrediente1;
    [SerializeField]
    TextMeshProUGUI Ingrediente2;
    [SerializeField]
    TextMeshProUGUI Ingrediente1Qta;
    [SerializeField]
    TextMeshProUGUI Ingrediente2Qta;

    InventoryScript inventory;
    NavMeshAgent agent;
    

    [SerializeField]
    TextMeshProUGUI InventoryIngrediente1;
    [SerializeField]
    TextMeshProUGUI InventoryIngrediente2;
    [SerializeField]
    TextMeshProUGUI InventoryIngrediente3;
    [SerializeField]
    TextMeshProUGUI InventoryIngrediente1Qta;
    [SerializeField]
    TextMeshProUGUI InventoryIngrediente2Qta;
    [SerializeField]
    TextMeshProUGUI InventoryIngrediente3Qta;

    [SerializeField]
    Slider slider;


    void Start()
    {
        RicettaCanvas.SetActive(false);
        InventoryCanvas.SetActive(false);
        inventory = AI.gameObject.GetComponent<InventoryScript>();
        agent = AI.gameObject.GetComponent<NavMeshAgent>();
        slider.maxValue = 4;
        slider.value = agent.speed;

    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            RicettaCanvas.SetActive(true);
        }
        else
        {
            RicettaCanvas.SetActive(false);
        }

        if (AI.ricetta == null)
        {
            NomeRicetta.text = "Nessuna Ricetta";
            Ingrediente1.text = "";
            Ingrediente2.text = "";
            Ingrediente1Qta.text = "";
            Ingrediente2Qta.text = "";
        }
        else 
        {
            NomeRicetta.text = AI.ricetta.NomeRicetta;
            foreach (Ingrediente ingrediente in AI.ricetta.ingredienti)
            {
                if (Ingrediente1.text == null || Ingrediente1.text == "") 
                {
                    Ingrediente1.text = ingrediente.IngridientName;
                    Ingrediente1Qta.text = "Quantità: " + ingrediente.Quantity.ToString();
                }
                else 
                {
                    Ingrediente2.text = ingrediente.IngridientName;
                    Ingrediente2Qta.text = "Quantità: " + ingrediente.Quantity.ToString();

                }
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            InventoryCanvas.SetActive(true);
        }
        else
        {
            InventoryCanvas.SetActive(false);
        }

        InventoryIngrediente1.text = inventory.ingrediente1.IngridientName;
        InventoryIngrediente2.text = inventory.ingrediente2.IngridientName;
        InventoryIngrediente3.text = inventory.ingrediente3.IngridientName;
        InventoryIngrediente1Qta.text = "Quantità: " + inventory.ingrediente1.Quantity.ToString();
        InventoryIngrediente2Qta.text = "Quantità: " + inventory.ingrediente2.Quantity.ToString();
        InventoryIngrediente3Qta.text = "Quantità: " + inventory.ingrediente3.Quantity.ToString();

        agent.speed = slider.value;



    }
}
