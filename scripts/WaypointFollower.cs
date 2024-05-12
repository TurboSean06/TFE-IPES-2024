using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Tableau contenant les points de passage que l'objet va suivre
    [SerializeField] GameObject[] waypoints;
    // Indice du point de passage actuel
    int currentWaypointIndex = 0;

    // Vitesse de déplacement de l'objet
    [SerializeField] float speed = 1f;

    void Update()
    {
        // Vérifie si la distance entre la position actuelle de l'objet et le point de passage suivant est inférieure à 0.1 unité
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            // Passe au point de passage suivant
            currentWaypointIndex++;
            // Si l'indice dépasse la longueur du tableau, revient au premier point de passage
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        // Déplace l'objet vers le point de passage suivant à une vitesse constante
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}