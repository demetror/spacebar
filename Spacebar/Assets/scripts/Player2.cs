﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {


    public Vector2 speed = new Vector2(50, 50);

    private Vector2 movement;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        float inputX = Input.GetAxis("Horizontal2");
        float inputY = Input.GetAxis("Vertical2");

        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        // Astuce pour ceux sous Mac car Ctrl + flèches est utilisé par le système
        Shield2 shield = GetComponentInChildren<Shield2>();
        if (Input.GetButton("Fire2"))
        {
            shield.Protect(movement);
        }
        if (Input.GetButton("RotaD2"))
        {
            shield.RotaGauche();
        }
        if (Input.GetButton("RotaG2"))
        {
            shield.RotaDroite();
        }
            WeaponShoot weapon = GetComponent<WeaponShoot>();
            if (weapon != null)
            {
                // false : le joueur n'est pas un ennemi
                weapon.Attack(false, 0);
            }
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
          );

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}

