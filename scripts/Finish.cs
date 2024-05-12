using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Cette méthode est appelée lorsque le joueur entre en collision avec l'objet auquel ce script est attaché
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui a déclenché la collision est le joueur
        if (other.gameObject.name == "joueur")
        {
            // Charge la scène suivante dans l'ordre de build lorsque le joueur atteint l'objectif
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}