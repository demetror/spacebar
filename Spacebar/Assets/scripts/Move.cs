using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public bool Enemy = true;

    public Vector2 speed = new Vector2(5, 5);

    public Vector2 direction = new Vector2(0, 1);

    public bool isBoss = false;
    private Vector2 movement;
    // Use this for initialization

    private WeaponShoot[] weapons;
    private Rigidbody2D[] rigidbodys;
    private Health[] lifes;

    void Awake()
    {
        // Récupération de toutes les armes de l'ennemi
        weapons = GetComponentsInChildren<WeaponShoot>();
        rigidbodys = GetComponentsInChildren<Rigidbody2D>();
        lifes = GetComponentsInChildren<Health>();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isBoss && Camera.main.transform.position.y >= transform.position.y)
        {
            movement.y = 3.0F;
            foreach (Health rigid in lifes)
            {
                // On fait tirer toutes les armes automatiquement
                if (rigid != null)
                {
                    rigid.isInvincible = false;
                }
            }
        }
        else
        {
            movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
        }
        if (!isBoss)
        {
            foreach (WeaponShoot weapon in weapons)
            {
                // On fait tirer toutes les armes automatiquement
                if (weapon != null && weapon.CanAttack)
                {
                    weapon.Attack(true, 0);
                }
            }
        }
    }

        private void FixedUpdate()
    {
        foreach (Rigidbody2D rigid in rigidbodys)
        {
            // On fait tirer toutes les armes automatiquement
            if (rigid != null)
            {
                rigid.velocity = movement;
            }
        }
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
