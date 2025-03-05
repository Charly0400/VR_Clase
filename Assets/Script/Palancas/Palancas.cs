using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Palancas : MonoBehaviour
{
    public XRLever palanca;
    bool virado = false;
    public bool puedeGirar = true;

    public GameObject bola;
    public Material bolaDesactivada;
    public Material bolaActivada;

    public GameObject controlador;

    void Start()
    {
        // Obtener la referencia al componente XRLever
        palanca = GetComponent<XRLever>();
        // Establecer el estado inicial de la palanca según su valor actual
        virado = palanca.value;

    }

    IEnumerator CambiarEstado()
    {
        yield return new WaitForSeconds(0.75f);
        puedeGirar = true;
        virado = !virado;

        if (virado)
        {
            bola.GetComponent<Renderer>().material = bolaActivada;
        }
        else
        {
            bola.GetComponent<Renderer>().material = bolaDesactivada;
        }

        controlador.GetComponent<PalancasPuzzle>().receberSignal(gameObject, virado);
    }

    public void Palanca()
    {
        Debug.Log("Activando");
        if (puedeGirar)
        {
            Debug.Log("se pudo girar");
            puedeGirar = false;
            StartCoroutine(CambiarEstado());
        }
    }
}
