using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cook : AIState
{
    public Cook(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricettaScript, Transform _idelSpot, Transform _cookingSpot, Transform _restingSpot, Transform _Ingrediente1Spot, Transform _Ingrediente2Spot, Transform _Ingrediente3Spot)
        : base(_npc, _agent, _ricettaScript, _idelSpot, _cookingSpot, _restingSpot, _Ingrediente1Spot, _Ingrediente2Spot, _Ingrediente3Spot)
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

        RicettaScript tmp_ricetta = npc.GetComponent<AIController>().ricetta;

        

        base.Update();
    }

    public override void Exit()
    {
        //TODO reset animazione
        Debug.Log("Uscito dall Cook");
        base.Exit();
    }
}
