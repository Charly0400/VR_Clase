using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
   public void startGame() {
        try {
            SceneManager.LoadScene("SampleScene");
        }
        catch {
            Debug.LogError("Proble Scene");
        }
    }

    public void Exit() {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Salir");
    }


}
