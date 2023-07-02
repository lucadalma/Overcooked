using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    CheckRecipe,
    Cook,
    GetIngredients,
    GoToSleep,
    GetUp,

}

public class AIState
{
    public enum Event
    {
        Enter,
        Update,
        Exit
    }

    public State name;
    protected Event stage;

    //Refs
    protected GameObject npc;
    protected AIState nextState;
    protected NavMeshAgent agent;
    protected RicettaScript ricetta;
    protected Transform IdleSpot;
    protected Transform CookingSpot;
    protected Transform ingredientsSpot;
    //protected Transform[] checkpoints;


    public AIState(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricettaScript)
    {
        stage = Event.Enter;
        npc = _npc;
        agent = _agent;
    }

    public virtual void Enter() { stage = Event.Update; }

    public virtual void Update() { stage = Event.Update; }

    public virtual void Exit() { stage = Event.Exit; }

    public AIState Process()
    {
        if (stage == Event.Enter) Enter();

        if (stage == Event.Update) Update();

        if (stage == Event.Exit)
        {
            Exit();
            return nextState;
        }

        return this;

    }

    //public bool CanSeePlayer()
    //{
    //    Vector3 direction = player.position - npc.transform.position;

    //    float angle = Vector3.Angle(direction, npc.transform.forward);

    //    if (direction.magnitude < visDist && angle < visAngle)
    //    {
    //        return true;
    //    }

    //    return false;

    //}

    //public bool CanSeeMe()
    //{
    //    Vector3 direction = npc.transform.position - Camera.main.transform.position;

    //    float angle = Vector3.Angle(direction, Camera.main.transform.forward);



    //    if (angle < visAngle)
    //    {
    //        return true;
    //    }

    //    return false;

    //}

    //public bool CanAttackPlayer()
    //{
    //    Vector3 direction = player.position - npc.transform.position;

    //    if (direction.magnitude < attackRange)
    //    {
    //        return true;
    //    }

    //    return false;
    //}

    //public bool IsPlayerToNear()
    //{
    //    Vector3 direction = npc.transform.position - player.position;

    //    float angle = Vector3.Angle(direction, npc.transform.forward);

    //    if (direction.magnitude < fleeRange && angle < escapeAngle)
    //    {
    //        Debug.Log("Escape");
    //        return true;
    //    }

    //    return false;
    //}

}
