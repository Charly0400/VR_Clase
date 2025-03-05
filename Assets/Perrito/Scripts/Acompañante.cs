using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Acompañante : BasicAgent
{
    [SerializeField] float followDistance;
    [SerializeField] float feedRadius;
    bool isFed = false;
    Transform player;

    void Update()
    {
        if (isFed)
        {
            FollowPlayer();
        }
        else
        {
            CheckForFeeding();
        }
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            Vector3 followDirection = SteeringBehaviours.seek(this, player.position);
            GetComponent<Rigidbody>().velocity = followDirection;
        }
    }

    void CheckForFeeding()
    {
        Collider[] perceivedObjects = Physics.OverlapSphere(transform.position, feedRadius);
        foreach (Collider col in perceivedObjects)
        {
            if (col.CompareTag("Player") && PlayerFeeds(this))
            {
                isFed = true;
                player = col.transform;
                return;
            }
        }
    }

    bool PlayerFeeds(Acompañante agent)
    {
        // Implement feeding logic here
        // Return true if the player feeds the agent
        return true;
    }
}