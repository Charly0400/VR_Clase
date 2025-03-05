using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Simon : MonoBehaviour
{
    public GameObject simon;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")

        simon.gameObject.SetActive(true);
    }


}
