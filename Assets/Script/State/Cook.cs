using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cook : AIState
{
    public Cook(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricettaScript, Transform _idelSpot, Transform _cookingSpot, Transform _restingSpot, Transform _Ingrediente1Spot, Transform _Ingrediente2Spot, Transform _Ingrediente3Spot, GameManager _gameManager)
        : base(_npc, _agent, _ricettaScript, _idelSpot, _cookingSpot, _restingSpot, _Ingrediente1Spot, _Ingrediente2Spot, _Ingrediente3Spot, _gameManager)
    {
        name = State.Cook;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entrato in Cook");
    }

    public override void Update()
    {
        agent.SetDestination(CookingSpot.position);

        Debug.Log("Inzio a cucinare");

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    RicettaScript tmp_ricetta = npc.GetComponent<AIController>().ricetta;

                    foreach (Ingrediente ingrediente in tmp_ricetta.ingredienti)
                    {
                        if (ingrediente.IngridientName == npc.GetComponent<InventoryScript>().ingrediente1.IngridientName)
                        {
                            npc.GetComponent<InventoryScript>().ingrediente1.Quantity -= ingrediente.Quantity;
                        }
                        else if (ingrediente.IngridientName == npc.GetComponent<InventoryScript>().ingrediente2.IngridientName)
                        {
                            npc.GetComponent<InventoryScript>().ingrediente2.Quantity -= ingrediente.Quantity;
                        }
                        else if (ingrediente.IngridientName == npc.GetComponent<InventoryScript>().ingrediente3.IngridientName)
                        {
                            npc.GetComponent<InventoryScript>().ingrediente3.Quantity -= ingrediente.Quantity;
                        }
                    }

                    npc.GetComponent<AIController>().ricetta.Isdone = true;

                    npc.GetComponent<AIController>().ricetta.gameObject.SetActive(false);

                    npc.GetComponent<AIController>().ricetta = null;

                    nextState = new Idle(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot, gameManager);
                    stage = Event.Exit;
                    return;
                }
            }
        }




        base.Update();
    }

    public override void Exit()
    {
        //TODO reset animazione
        Debug.Log("Uscito dall Cook");
        base.Exit();
    }
}
