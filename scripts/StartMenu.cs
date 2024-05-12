using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Cette méthode est appelée lorsqu'on démarre une nouvelle partie depuis le menu de démarrage
    public void StartGame()
    {
        // Charge la scène suivante dans l'ordre de build pour commencer le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}