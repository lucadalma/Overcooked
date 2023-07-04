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
    public Transform restingSpot;
    [SerializeField]
    public Transform Ingredient1Spot;
    [SerializeField]
    public Transform Ingredient2Spot;
    [SerializeField]
    public Transform Ingredient3Spot;
    [SerializeField]
    public GameManager gameManager;

    NavMeshAgent agent;
    AIState currentState;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = new Idle(gameObject, agent, ricetta, IdleSpot, CookingSpot, restingSpot, Ingredient1Spot, Ingredient2Spot, Ingredient3Spot, gameManager);
    }

    private void Update()
    {
        currentState = currentState.Process();
    }
}
