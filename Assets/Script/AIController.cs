using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField]
    public RicettaScript ricetta;
    [SerializeField]
    public Transform IdleSpot;
    [SerializeField]
    public Transform CookingSpot;
    [SerializeField]
    public Transform ingredientsSpot;

    NavMeshAgent agent;
    AIState currentState;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = new Idle(gameObject, agent, ricetta);
    }

    private void Update()
    {
        currentState = currentState.Process();
    }
}
