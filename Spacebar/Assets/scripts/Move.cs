using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public bool Enemy = true;

    public Vector2 speed = new Vector2(5, 5);

    public Vector2 direction = new Vector2(0, 1);

    private Vector2 movement;
    // Use this for initialization

    private WeaponShoot[] weapons;

    void Awake()
    {
        // Récupération de toutes les armes de l'ennemi
        weapons = GetComponentsInChildren<WeaponShoot>();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);

        foreach (WeaponShoot weapon in weapons)
        {
            // On fait tirer toutes les armes automatiquement
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.gameObject.GetComponent<Player>();
        if (player != null)
            Destroy(gameObject);
    }

        private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
