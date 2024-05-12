using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;

    private void Update()
    {
        // Vérifie si le joueur est tombé en dessous de la limite acceptable
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le joueur entre en collision avec un objet Enemy Body
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
    }

    void Die()
    {
        // Ajoutez ici des effets visuels ou des animations de mort si nécessaire

        // Désactive le joueur et marque-le comme mort
        gameObject.SetActive(false);
        dead = true;

        // Réinitialise le niveau après un court délai
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    void ReloadLevel()
    {
        // Recharge le niveau actuel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}