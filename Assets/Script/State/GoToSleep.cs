using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToSleep : AIState
{
    public GoToSleep(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricettaScript, Transform _idelSpot, Transform _cookingSpot, Transform _restingSpot, Transform _Ingrediente1Spot, Transform _Ingrediente2Spot, Transform _Ingrediente3Spot, GameManager _gameManager)
        : base(_npc, _agent, _ricettaScript, _idelSpot, _cookingSpot, _restingSpot, _Ingrediente1Spot, _Ingrediente2Spot, _Ingrediente3Spot, _gameManager)
    {
        name = State.GoToSleep;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entrato in Sleep");
    }

    public override void Update()
    {
        //go to sleep destination
        agent.SetDestination(restingSpot.position);

        //if is day go to idle
        if (gameManager.isDay) 
        {
            nextState = new Idle(npc, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingrediente1Spot, Ingrediente2Spot, Ingrediente3Spot, gameManager);
            stage = Event.Exit;
            return;
        }


        base.Update();
    }

    public override void Exit()
    {
        Debug.Log("Uscito dallo Sleep");
        base.Exit();
    }
}
