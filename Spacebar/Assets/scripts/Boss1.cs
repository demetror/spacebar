﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

    private WeaponShoot[] weapons;
    private int rotate = 1;
    private int time_rotate = 0;
    void Awake()
    {
        // Récupération de toutes les armes de l'ennemi
        weapons = GetComponentsInChildren<WeaponShoot>();
    }

    void Update()
    {
        time_rotate++;
        if (time_rotate == 600)
        {
            time_rotate = 0;
            if (rotate == 1)
                rotate = -1;
            else
                rotate = 1;
        }
        if (!GetComponent<Health>().isInvincible)
        {
            foreach (WeaponShoot weapon in weapons)
            {
                // On fait tirer toutes les armes automatiquement
                if (weapon != null && weapon.CanAttack)
                {
                    weapon.Attack(true, rotate);
                    
                }
                if (GetComponent<Health>().hp < 50)
                {
                    weapon.setActivate(true, 1);
                }
                if (GetComponent<Health>().hp < 20)
                {
                    weapon.setActivate(true, 2);
                }
            }
        }
    }
   
}
