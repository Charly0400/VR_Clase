using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Escape : BasicAgent
{
    [SerializeField] float territoryRadius;
    [SerializeField] Transform territoryPercept;
    [SerializeField] AgressiveAgentStates agentState;
    Collider[] perceivedObjects;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agentState = AgressiveAgentStates.None;
    }
    void Update()
    {
        perceptionManager();
        decisionManager();
    }
    private void FixedUpdate()
    {
        perceivedObjects = Physics.OverlapSphere(territoryPercept.position, territoryRadius);

    }
    void perceptionManager()
    {
        target = null;
        if (perceivedObjects != null)
        {
            foreach (Collider tmp in perceivedObjects)
            {
                if (tmp.CompareTag("Player"))
                {
                    target = tmp.transform;
                }
            }
        }
    }
    void decisionManager()
    {
        AgressiveAgentStates newState;
        if (target == null)
        {
            newState = AgressiveAgentStates.Wander;
        }
        else if (target.GetComponent<Rigidbody>().mass < rb.mass)
        { // Corregido aquí
            newState = AgressiveAgentStates.Pursuit;
            if (Vector3.Distance(transform.position, target.position) < stopThreshold)
            {
                newState = AgressiveAgentStates.Attack;
            }
        }
        else
        {
            newState = AgressiveAgentStates.None;
        }
        changeAgentState(newState);
        actionManager();
        movementManager();
    }

    /// <summary>
    /// 
    /// Changes the state of the agent only if its a new state
    /// </summary>
    /// <param name="t_newState">The new state of the agent.</param>
    void changeAgentState(AgressiveAgentStates t_newState)
    {
        if (agentState == t_newState)
        {
            return;
        }
        agentState = t_newState;
        if (agentState != AgressiveAgentStates.Wander)
        {
            wanderNextPosition = null;
        }
    }
    void actionManager()
    {
        switch (agentState)
        {
            case AgressiveAgentStates.None:
                break;
            case AgressiveAgentStates.Attack:
                // biting();
                break;
        }
    }
    void movementManager()
    {
        switch (agentState)
        {
            case AgressiveAgentStates.None:
                rb.velocity = Vector3.zero;
                break;
            case AgressiveAgentStates.Pursuit:
                pursuiting();
                break;
            case AgressiveAgentStates.Attack:
                attacking();
                break;
            case AgressiveAgentStates.Wander:
                wandering();
                break;
        }
    }

    private void wandering()
    {
        if ((wanderNextPosition == null) || (Vector3.Distance(transform.position, wanderNextPosition.Value) < 0.5f))
        {
            wanderNextPosition = SteeringBehaviours.wanderNextPos(this);
        }
        rb.velocity = SteeringBehaviours.seek(this, wanderNextPosition.Value);
    }
    void attacking()
    {
        Debug.Log("Attacking");
    }

    void pursuiting()
    {
        maxVel *= 2;
        rb.velocity = SteeringBehaviours.seek(this, target.position);
        rb.velocity = SteeringBehaviours.arrival(this, target.position, slowingRadius, stopThreshold);
        if (Vector3.Distance(transform.position, target.position) <= slowingRadius)
        {

        }
        maxVel /= 2;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(territoryPercept.position, territoryRadius);

    }
    private enum AgressiveAgentStates
    {
        None,
        Pursuit,
        Attack,
        Wander
    }
}
/*
[SerializeField] float safeDistance;
    Collider[] perceivedObjects;

    void Update()
    {
        perceivedObjects = Physics.OverlapSphere(transform.position, safeDistance);
        FleeFromNearbyObjects();
    }

    void FleeFromNearbyObjects()
    {
        foreach (Collider col in perceivedObjects)
        {
            if (col.CompareTag("Player") || col.CompareTag("Predator"))
            {
                Vector3 fleeDirection = SteeringBehaviours.flee(this, col.transform.position);
                GetComponent<Rigidbody>().velocity = fleeDirection;
                return;
            }
        }
        // If no threats are near, do nothing or wander
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    } 
}*/