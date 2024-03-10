using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;

    public void SetPlayerTransform(Transform playerTransform)
    {
        this.player = playerTransform;
    }

    void Update()
    {
        if (player != null)
        {
            // Establece la posición del jugador como destino del agente
            agent.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Colisión con Jugador");
            //Destroy(other.gameObject);

        }

    }


}
