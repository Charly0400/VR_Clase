using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ghost"))
        {
            Debug.Log("Colisi�n con Fantasma");
            Destroy(collision.gameObject);
        }
    }
}
