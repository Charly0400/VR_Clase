using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            Debug.Log("Colisión con Fantasma");
            Destroy(other.gameObject);

        }


    }
}
