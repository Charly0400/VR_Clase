using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    BarraVida barraVida;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    // Start is called before the first frame update
    void Start()
    {
        barraVida = GameObject.FindWithTag("Player").GetComponent<BarraVida>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Hola");
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                barraVida.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
