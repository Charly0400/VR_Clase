using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Agrupación : BasicAgent
{
    [SerializeField] float groupRadius;
    [SerializeField] float exploreRadius;
    Collider[] perceivedAgents;

    void Update()
    {
        perceivedAgents = Physics.OverlapSphere(transform.position, groupRadius);
        GroupOrExplore();
    }

    void GroupOrExplore()
    {
        Transform nearestAgent = FindNearestAgent();
        if (nearestAgent != null)
        {
            MoveTowards(nearestAgent.position);
        }
        else
        {
            Explore();
        }
    }

    Transform FindNearestAgent()
    {
        Transform nearestAgent = null;
        float nearestDistance = float.MaxValue;
        foreach (Collider col in perceivedAgents)
        {
            if (col.CompareTag("GroupingAgent"))
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < nearestDistance)
                {
                    nearestAgent = col.transform;
                    nearestDistance = distance;
                }
            }
        }
        return nearestAgent;
    }

    void MoveTowards(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = SteeringBehaviours.seek(this, targetPosition);
        GetComponent<Rigidbody>().velocity = desiredVelocity;
    }

    void Explore()
    {
        if (wanderNextPosition == null || Vector3.Distance(transform.position, wanderNextPosition.Value) < 1f)
        {
            wanderNextPosition = SteeringBehaviours.wanderNextPos(this);
        }
        MoveTowards(wanderNextPosition.Value);
    }
}
