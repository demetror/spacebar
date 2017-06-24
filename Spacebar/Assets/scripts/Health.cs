﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /// <summary>
    /// Points de vies
    /// </summary>
    public int hp = 1;

    /// <summary>
    /// Ennemi ou joueur ?
    /// </summary>
    public bool isEnemy = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Est-ce un tir ?
        Shoot shot = collider.gameObject.GetComponent<Shoot>();
        Move enemy = collider.gameObject.GetComponent<Move>();
        if (enemy != null && enemy.Enemy == true)
        {
            Destroy(gameObject);
        }
        if (shot != null)
        {
            // Tir allié
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;

                // Destruction du projectile
                // On détruit toujours le gameObject associé
                // sinon c'est le script qui serait détruit avec ""this""
                Destroy(shot.gameObject);

                if (hp <= 0)
                {
                    // Destruction !
                    Destroy(gameObject);
                }
            }
        }
    }
}
