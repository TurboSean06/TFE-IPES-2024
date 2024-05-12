using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forwardsForce = 40f; // Force de déplacement vers l'avant
    public float sidewaysForce = 40f; // Force de déplacement latéral
    public float jumpForce = 10f; // Force du saut

    [SerializeField] Transform groundCheck; // Référence au point de vérification au sol
    [SerializeField] LayerMask ground; // Layer auquel le sol appartient

    private Rigidbody rb; // Référence au Rigidbody du joueur
    private bool hasJumped = false; // Variable pour suivre l'état du saut

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Récupération du Rigidbody attaché à ce GameObject
    }

    void FixedUpdate()
    {
        MovePlayer(); // Appel de la fonction de déplacement à chaque frame physique
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Entrée de déplacement latéral
        float verticalInput = Input.GetAxis("Vertical"); // Entrée de déplacement vers l'avant

        // Calcul du vecteur de déplacement en fonction des entrées
        Vector3 movement = new Vector3(sidewaysForce * horizontalInput, 0, forwardsForce * verticalInput);
        rb.AddForce(movement * Time.deltaTime, ForceMode.VelocityChange); // Application de la force de déplacement

        float friction = 5f; // Coefficient de friction
        rb.AddForce(-rb.velocity * friction * Time.deltaTime, ForceMode.VelocityChange); // Application de la friction

        float maxSpeed = 10f; // Vitesse maximale autorisée
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed); // Limite la vitesse maximale du joueur
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped && IsGrounded()) // Vérification de l'entrée de saut et des conditions pour sauter
        {
            Jump(); // Appel de la fonction de saut
            hasJumped = true; // Mise à jour de l'état de saut
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Application de la force de saut
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head")) // Vérification de la collision avec la tête de l'ennemi
        {
            Destroy(collision.transform.parent.gameObject); // Destruction de l'objet parent de la tête de l'ennemi
            Jump(); // Saut supplémentaire suite à la collision
        }
        
        if (collision.gameObject.CompareTag("Ground")) // Vérification de la collision avec le sol
        {
            hasJumped = false; // Réinitialisation de l'état de saut
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground); // Vérifie si le joueur touche le sol
    }
}
