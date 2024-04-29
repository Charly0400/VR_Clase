using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portal;
    [SerializeField] private Animator animatorPortal;
    public void Portal_ON()
    {
        portal.SetActive(true);
        animatorPortal.Play("Open");
        Debug.Log("Ok");

    }


}
