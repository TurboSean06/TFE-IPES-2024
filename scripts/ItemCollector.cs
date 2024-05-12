using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Déclaration de la variable pour stocker le nombre de pièces collectées
    int coins = 0;

    // Référence au composant Text qui affichera le nombre de pièces
    [SerializeField] Text coinsText;

    // Cette méthode est appelée lorsque l'objet auquel ce script est attaché entre en collision avec un autre objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet avec lequel il y a collision est un "Coin"
        if (other.gameObject.CompareTag("Coin"))
        {
            // Détruit l'objet "Coin" avec lequel il y a collision
            Destroy(other.gameObject);
            // Incrémente le nombre de pièces collectées
            coins++;
            // Met à jour le texte affichant le nombre de pièces collectées
            coinsText.text = "Pièces: " + coins;
        }
    }
}