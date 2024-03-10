using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject gameOverPanel, cameraPlayer, vidaPanel;
    public static CanvasManager referenceCanvas;

    void Start()
    {
        referenceCanvas = this;
    }
    public void Salir()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Salir");
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true); 
        vidaPanel.SetActive(false); 
        cameraPlayer.SetActive(true); 
       
    }
}
