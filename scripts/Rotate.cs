using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // La vitesse de rotation autour de l'axe X
    [SerializeField] float speedX;
    // La vitesse de rotation autour de l'axe Y
    [SerializeField] float speedY;
    // La vitesse de rotation autour de l'axe Z
    [SerializeField] float speedZ;

    // Cette méthode est appelée à chaque image
    void Update()
    {
        // Effectue une rotation sur l'objet selon les vitesses spécifiées et le temps écoulé depuis la dernière frame
        transform.Rotate(360 * speedX * Time.deltaTime, 360 * speedY * Time.deltaTime, 360 * speedZ * Time.deltaTime);
    }
}