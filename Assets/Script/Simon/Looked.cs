using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looked : Interactable
{

    //public AudioClip audioClip;
    public int ID;


    public override void OnInteraction()
    {
        Debug.Log("Trying to acces");

        if (Inventory.HasKey(ID))
            OpenLock();

        else
            Debug.Log("Can not open");
        
    }

    public void OpenLock()
    {
        
        Debug.Log("Open");
        GetComponent<Animator>().enabled = true;
        GetComponent<AudioSource>().enabled = true;

    }
}