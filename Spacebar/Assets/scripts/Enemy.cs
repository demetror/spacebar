using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool hasSpawn;
    private Move moveScript;
    private WeaponShoot[] weapons;

    void Awake()
    {
        // Récupération de toutes les armes de l'ennemi
        weapons = GetComponentsInChildren<WeaponShoot>();

        // Récupération du script de mouvement lié
        moveScript = GetComponent<Move>();
    }

    // 1 - Disable everything
    void Start()
    {
        hasSpawn = false;

        // On désactive tout
        // -- collider
        GetComponent<Collider2D>().enabled = false;
        // -- Mouvement
        moveScript.enabled = false;
        // -- Tir
        foreach (WeaponShoot weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

    void Update()
    {
        // 2 - On vérifie si l'ennemi est apparu à l'écran
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            // On fait tirer toutes les armes automatiquement

            // 4 - L'ennemi n'a pas été détruit, il faut faire le ménage
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }

    // 3 - Activation
    private void Spawn()
    {
        hasSpawn = true;

        // On active tout
        // -- Collider
        GetComponent<Collider2D>().enabled = true;
        // -- Mouvement
        moveScript.enabled = true;
        // -- Tir
        foreach (WeaponShoot weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
