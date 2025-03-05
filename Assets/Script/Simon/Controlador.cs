using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public Button[] cubos;

    public GameObject premio;
    public List<int> listaAleatoria = new List<int>();

    public bool listaLlena;
    public bool turnoPC;
    public bool turnoUsuario;

    public int contador;
    public int contadorUsiario;
    public int nivelActual;

    [Range(0.1f, 2f)]
    public float velocidad;


    void Start()
    {
        LlenarListaAleatoria();
        turnoPC = true;
        Invoke("TurnoPC", 1f);
    }


    void LlenarListaAleatoria()
    {
        for (int i = 0; i <= 500; i++)
        {
            listaAleatoria.Add(Random.Range(0, 4));
        }
        listaLlena = true;
    }

    public void TurnoPC()
    {
        if (listaLlena && turnoPC)
        {
            cubos[listaAleatoria [contador]].ActivarCubo();

            if (contador >= nivelActual)
            {
                nivelActual++;
                CambiarEstado();
            }
            else
            {
                contador++;
            }

            Invoke("TurnoPC", velocidad);

            if (nivelActual == 4)
            {
                Invoke("FinDelJuego", 0.1f);
            }
                

        }
    }

    public void ClickUsuario(int idCubo)
    {
        if (idCubo != listaAleatoria [contadorUsiario])
        {
            Debug.Log("Game Over");
            Invoke("Reiniciar", 0.1f);
            return;
        }

            if (contadorUsiario == contador)
        {

            CambiarEstado();
        }
        else
        {
            contadorUsiario++;
        }
    }

    public void CambiarEstado()
    {
        if (turnoPC)
        {
            turnoPC = false;
            turnoUsuario = true;
        }

        else
        {
            turnoPC = true;
            turnoUsuario = false;
            contador = 0;
            contadorUsiario = 0;
            Invoke("TurnoPC", 1.2f);
        }
    }

    public void GameOver()
    {
        turnoPC = false;
        turnoUsuario = false;
    }

    public void Reiniciar()
    {
        contador = 0;
        contadorUsiario = 0;
        nivelActual = 0;
        listaAleatoria.Clear();
        LlenarListaAleatoria ();
        turnoPC=true;
        Invoke("TurnoPC", 1f);
    }

    public void FinDelJuego()
    {
        Debug.Log("HOOHO");
        premio.SetActive(false);
    }

}
