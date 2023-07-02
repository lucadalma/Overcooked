using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetIngredient2 : AIState
{
    public GetIngredient2(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricettaScript, Transform _idelSpot, Transform _cookingSpot, Transform _restingSpot, Transform _Ingrediente1Spot, Transform _Ingrediente2Spot, Transform _Ingrediente3Spot)
       : base(_npc, _agent, _ricettaScript, _idelSpot, _cookingSpot, _restingSpot, _Ingrediente1Spot, _Ingrediente2Spot, _Ingrediente3Spot)
    {
        name = State.GetIngredient2;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entrato in GetIngredient2");
    }

    public override void Update()
    {

        agent.SetDestination(Ingrediente2Spot.position);

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    nextState = new CheckIngredients(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot);
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
        Debug.Log("Uscito da GetIngredient2");
        base.Exit();
    }
}