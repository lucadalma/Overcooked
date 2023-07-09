using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckIngredients : AIState
{

    public CheckIngredients(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricettaScript, Transform _idelSpot, Transform _cookingSpot, Transform _restingSpot, Transform _Ingrediente1Spot, Transform _Ingrediente2Spot, Transform _Ingrediente3Spot, GameManager _gameManager)
        : base(_npc, _agent, _ricettaScript, _idelSpot, _cookingSpot, _restingSpot, _Ingrediente1Spot, _Ingrediente2Spot, _Ingrediente3Spot, _gameManager)
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

        //check foreach ingridient and check inventory
        foreach (Ingrediente tmp_ingredient in tmp_ingredients)
        {
            if (tmp_ingredient.IngridientName == npc.GetComponent<InventoryScript>().ingrediente1.IngridientName && tmp_ingredient.Quantity > npc.GetComponent<InventoryScript>().ingrediente1.Quantity)
            {
                nextState = new GetIngredient1(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot, gameManager);
                stage = Event.Exit;
                return;
            }
            else if (tmp_ingredient.IngridientName == npc.GetComponent<InventoryScript>().ingrediente2.IngridientName && tmp_ingredient.Quantity > npc.GetComponent<InventoryScript>().ingrediente2.Quantity)
            {
                nextState = new GetIngredient2(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot, gameManager);
                stage = Event.Exit;
                return;
            }
            else if (tmp_ingredient.IngridientName == npc.GetComponent<InventoryScript>().ingrediente3.IngridientName && tmp_ingredient.Quantity > npc.GetComponent<InventoryScript>().ingrediente3.Quantity)
            {
                nextState = new GetIngredient3(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot, gameManager);
                stage = Event.Exit;
                return;

            }

        }

        nextState = new Cook(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot, gameManager);
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
