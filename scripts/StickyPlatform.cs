using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // Cette méthode est appelée lorsque la collision commence avec un autre objet
    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet en collision est le joueur
        if (collision.gameObject.name == "joueur")
        {
            // Fixe le joueur comme enfant de cette plateforme
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // Cette méthode est appelée lorsque la collision avec un autre objet se termine
    private void OnCollisionExit(Collision collision)
    {
        // Vérifie si l'objet en collision est le joueur
        if (collision.gameObject.name == "joueur")
        {
            // Détache le joueur de cette plateforme
            collision.gameObject.transform.SetParent(null);
        }
    }
}