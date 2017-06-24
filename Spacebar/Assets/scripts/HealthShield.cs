using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShield : MonoBehaviour
{
    /// <summary>
    /// Points de vies
    /// </summary>
    public int hp = 1;
    int heal = 0;
    /// <summary>
    /// Ennemi ou joueur ?
    /// </summary>
    public bool isEnemy = true;
    public bool shieldBreak = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Est-ce un tir ?
        Shoot shot = collider.gameObject.GetComponent<Shoot>();
        Move enemy = collider.gameObject.GetComponent<Move>();
        if (enemy != null && enemy.Enemy == true)
        {
            hp -= 20;
        }
        if (shot != null)
        {
            // Tir allié
            if (shot.isEnemyShot != isEnemy && !shieldBreak)
            {
                hp -= shot.damage * 5;

                // Destruction du projectile
                // On détruit toujours le gameObject associé
                // sinon c'est le script qui serait détruit avec ""this""
                shot.isEnemyShot = false;
                shot.direction.x = shot.direction.x * -1;
                shot.direction.y = shot.direction.y * -1;
                shot.GetComponent<SpriteRenderer>().sprite = Resources.Load("Friend", typeof(Sprite)) as Sprite;
            }
            if (hp <= 0)
            {
                hp = 1;
                // Destruction !
                shieldBreak = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Broken", typeof(Sprite)) as Sprite;
            }
            if (hp >= 30 && shieldBreak)
            {
                shieldBreak = false;
          }
        }
    }

    private void Update()
    {
        heal++;
        if (heal >= 30)
        {
            if (hp < 100)
            hp++;
            heal = 0;
        }
        if (hp >= 70)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("yellow", typeof(Sprite)) as Sprite;
        }
        else if (hp >= 30)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("True", typeof(Sprite)) as Sprite;
        }
    }
}
