using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckIngredients : AIState
{

    public CheckIngredients(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricettaScript, Transform _idelSpot, Transform _cookingSpot, Transform _restingSpot, Transform _Ingrediente1Spot, Transform _Ingrediente2Spot, Transform _Ingrediente3Spot)
        : base(_npc, _agent, _ricettaScript, _idelSpot, _cookingSpot, _restingSpot, _Ingrediente1Spot, _Ingrediente2Spot, _Ingrediente3Spot)
    {
        name = State.CheckIngredients;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entrato in CheckIngredients");
    }

    public override void Update()
    {

        Ingrediente[] tmp_ingredients = npc.GetComponent<AIController>().ricetta.ingredienti;

        foreach (Ingrediente tmp_ingredient in tmp_ingredients)
        {
            if (tmp_ingredient.IngridientName == npc.GetComponent<InventoryScript>().ingrediente1.IngridientName && tmp_ingredient.Quantity > npc.GetComponent<InventoryScript>().ingrediente1.Quantity)
            {
                //Ricarica specifico ingrediente
                agent.SetDestination(Ingrediente1Spot.position);
            }
            else if (tmp_ingredient.IngridientName == npc.GetComponent<InventoryScript>().ingrediente2.IngridientName && tmp_ingredient.Quantity > npc.GetComponent<InventoryScript>().ingrediente2.Quantity)
            {
                //Ricarica specifico ingrediente
                agent.SetDestination(Ingrediente2Spot.position);
            }
            else if (tmp_ingredient.IngridientName == npc.GetComponent<InventoryScript>().ingrediente3.IngridientName && tmp_ingredient.Quantity > npc.GetComponent<InventoryScript>().ingrediente3.Quantity)
            {
                //Ricarica specifico ingrediente
                agent.SetDestination(Ingrediente3Spot.position);

            }

        }

        //nextState = new Cook(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot);
        stage = Event.Exit;
        return;

        base.Update();
    }

    public override void Exit()
    {
        //TODO reset animazione
        Debug.Log("Uscito dall CheckIngredients");
        base.Exit();
    }

}