using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    /// <summary>
    /// Points de vies
    /// </summary>
    public int hp = 1;

    /// <summary>
    /// Ennemi ou joueur ?
    /// </summary>
    public bool isEnemy = true;

    public bool isInvincible = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Est-ce un tir ?
        Shoot shot = collider.gameObject.GetComponent<Shoot>();
        Move enemy = collider.gameObject.GetComponent<Move>();
        Player player = collider.gameObject.GetComponent<Player>();
        if (enemy != null || player != null)
        {
            if (!isInvincible)
            {
                hp -= 20;

                if (hp <= 0)
                {
                    // Destruction !
                    Destroy(gameObject);
                }
            }
        }
        if (shot != null)
        {
            // Tir allié
            if (shot.isEnemyShot != isEnemy)
            {
                if (!isInvincible)
                {
                    hp -= shot.damage;

                    // Destruction du projectile
                    // On détruit toujours le gameObject associé
                    // sinon c'est le script qui serait détruit avec ""this""

                    if (hp <= 0)
                    {
                        // Destruction !
                        Destroy(gameObject);
                    }
                }
                Destroy(shot.gameObject);
            }
        }
    }
}
