using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    CheckIngredients,
    GetIngredient1,
    GetIngredient2,
    GetIngredient3,
    Cook,
    GoToSleep,
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
    protected Transform restingSpot;
    protected Transform Ingrediente1Spot;
    protected Transform Ingrediente2Spot;
    protected Transform Ingrediente3Spot;
    protected GameManager gameManager;
    //protected Transform[] checkpoints;


    public AIState(GameObject _npc, NavMeshAgent _agent, RicettaScript _ricetta, Transform _idleSpot, Transform _cookingSpot, Transform _restingSpot, Transform _Ingrediente1Spot, Transform _Ingrediente2Spot, Transform _Ingrediente3Spot, GameManager _gameManager)
    {
        stage = Event.Enter;
        npc = _npc;
        agent = _agent;
        ricetta = _ricetta;
        IdleSpot = _idleSpot;
        CookingSpot = _cookingSpot;
        restingSpot = _restingSpot;
        Ingrediente1Spot = _Ingrediente1Spot;
        Ingrediente2Spot = _Ingrediente2Spot;
        Ingrediente3Spot = _Ingrediente3Spot;
        gameManager = _gameManager;
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
