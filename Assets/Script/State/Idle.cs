using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricettaScript, Transform _idelSpot, Transform _cookingSpot, Transform _restingSpot, Transform _Ingrediente1Spot, Transform _Ingrediente2Spot, Transform _Ingrediente3Spot, GameManager _gameManager)
        : base(_npc, _agent, _ricettaScript, _idelSpot, _cookingSpot, _restingSpot, _Ingrediente1Spot, _Ingrediente2Spot, _Ingrediente3Spot, _gameManager)
    {
        name = State.Idle;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entrato in Idle");
    }

    public override void Update()
    { 
        agent.SetDestination(IdleSpot.position);
        if (gameManager.isDay)
        {
            if (npc.GetComponent<AIController>().ricetta != null)
            {
                nextState = new CheckIngredients(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot, gameManager);
                stage = Event.Exit;
                return;
            }
        }
        else if (gameManager.isNight) 
        {
            nextState = new GoToSleep(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot, gameManager);
            stage = Event.Exit;
            return;
        }

        base.Update();
    }

    public override void Exit()
    {
        //TODO reset animazione
        Debug.Log("Uscito dall'Idle");
        base.Exit();
    }
}
