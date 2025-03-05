using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryBox : MonoBehaviour {

    TerritoryAgent rhino;

    private void Start() {
        rhino = GameObject.Find("Rhino_Rig").GetComponent<TerritoryAgent>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            rhino.isEnemyInside();
            rhino.setTarget(other.transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            rhino.isEnemyInside();
            rhino.setTarget(gameObject.transform);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        // Dibuja un cubo de wireframe usando el tamaño y posición del collider del cubo
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider != null) {
            Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.transform.localScale);
        }
    }
}
