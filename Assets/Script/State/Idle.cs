using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : AIState
{
    public Idle(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricettaScript)
        : base(_npc, _agent, _ricettaScript)
    {
        name = State.Idle;
    }

    public override void Enter()
    {
        //TODO: Set animazione di Idle;
        base.Enter();
    }

    public override void Update()
    {
        //if (CanSeePlayer())
        //{
        //    if (CanSeeMe())
        //    {
        //        nextState = new Hide(npc, agent, checkpoints);
        //        stage = Event.Exit;
        //        return;
        //    }
        //    else
        //    {
        //        nextState = new Chase(npc, agent, checkpoints);
        //        stage = Event.Exit;
        //        return;
        //    }
        //}

        //if (Random.Range(0, 100) < 10)
        //{
        //    nextState = new Patrol(npc, agent, checkpoints);
        //    stage = Event.Exit;
        //    return;
        //}

        base.Update();
    }

    public override void Exit()
    {
        //TODO reset animazione
        base.Exit();
    }
}
