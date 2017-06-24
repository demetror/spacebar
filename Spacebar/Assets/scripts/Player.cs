using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public Vector2 speed = new Vector2(50, 50);

    private Vector2 movement;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        bool shoot = Input.GetButton("Fire1");
        // Astuce pour ceux sous Mac car Ctrl + flèches est utilisé par le système

        if (shoot)
        {
            WeaponShoot weapon = GetComponent<WeaponShoot>();
            if (weapon != null)
            {
                // false : le joueur n'est pas un ennemi
                weapon.Attack(false);
            }
        }


    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}

