using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    // Cette classe gère le menu de fin du jeu.

    // Méthode appelée lorsqu'on quitte le jeu.
    public void QuitGame()
    {
        // Quitte l'application.
        Application.Quit();
    }
}