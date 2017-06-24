using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield2 : MonoBehaviour
{
    private WeaponShoot[] weapons;
    private Vector2 movement;
    private int rotation = 0;
    // Update is called once per frame

    private void Awake()
    {
        weapons = GetComponentsInChildren<WeaponShoot>();
    }
    void Start()
    {
    }

    void Update()
    {
        if (GetComponent<HealthShield2>().hp >= 70)
        {
            foreach (WeaponShoot weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(false, 0);
                }
            }
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

    public void Protect(Vector2 pos)
    {
        movement = pos;
    }

    public void RotaGauche()
    {
        rotation = rotation - 1;
    }

    public void RotaDroite()
    {
        rotation = rotation + 1;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
        GetComponent<Rigidbody2D>().MoveRotation(rotation);
    }



}