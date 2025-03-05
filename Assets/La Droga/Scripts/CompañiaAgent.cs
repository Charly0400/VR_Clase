using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class CompañiaAgent : BasicAgent
{
    [SerializeField] AgressiveAgentStates agentState;
    string currentAnimationStateName;
    [SerializeField] Rigidbody rb;
    bool feeded = false;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agentState = AgressiveAgentStates.Idle;
        currentAnimationStateName = "";
    }

    void Update()
    {
        decisionManager();
    }

    void decisionManager()
    {
        AgressiveAgentStates newState;
        if (!feeded)
        {
            newState = AgressiveAgentStates.Idle;
        }
        else
        {
            newState = AgressiveAgentStates.Seeking;
            if (Vector3.Distance(transform.position, target.position) < stopThreshold)
            {
                newState = AgressiveAgentStates.Idle;
            }
        }
        changeAgentState(newState);
        movementManager();
    }

    void changeAgentState(AgressiveAgentStates t_newState)
    {
        if (agentState == t_newState)
        {
            return;
        }
        agentState = t_newState;
    }

    void movementManager()
    {
        switch (agentState)
        {
            case AgressiveAgentStates.Idle:
                idling();
                break;
            case AgressiveAgentStates.Seeking:
                seeking();
                break;
        }
    }

    public void feed(Transform t_target)
    {
        target = t_target;
        feeded = true;
    }

    private void seeking()
    {
        if (!currentAnimationStateName.Equals("walk"))
        {
            animator.Play("Walk", 0);
            currentAnimationStateName = "walk";
        }
        maxVel *= 2;
        rb.velocity = SteeringBehaviours.seek(this, target.position);
        rb.velocity = SteeringBehaviours.arrival(this, target.position, slowingRadius, stopThreshold);
        maxVel /= 2;
    }

    private void idling()
    {
        if (!currentAnimationStateName.Equals("idle"))
        {
            animator.Play("Idle", 0);
            currentAnimationStateName = "idle";
        }
        rb.velocity = Vector3.zero;
    }

    private enum AgressiveAgentStates
    {
        Idle,
        Seeking
    }
}
