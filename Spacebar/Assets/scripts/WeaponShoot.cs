using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour {

    public Transform shotPrefab;

    /// <summary>
    /// Temps de rechargement entre deux tirs
    /// </summary>
    public float shootingRate = 0.25f;
    public float shootingSpeed = 5;
    public float shootingLife = 1;
    public int damage = 1;
    public float rotation = 0;
    public float savedY = 0;
    public bool activate = true;
    public int id = 0;

    //--------------------------------
    // 2 - Rechargement
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
        rotation = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void setActivate(bool activated, int id_tmp)
    {
        if (id == id_tmp)
        activate = activated;
    }

    public void Attack(bool isEnemy, int rotate)
    {
        if (CanAttack && activate)
        {
            shootCooldown = shootingRate;

            // Création d'un objet copie du prefab
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Position
            shotTransform.position = transform.position;

            // Propriétés du script
            Shoot shot = shotTransform.gameObject.GetComponent<Shoot>();
            if (shot != null)
            {
                GetComponent<Rigidbody2D>().MoveRotation(rotation);
                shot.life = shootingLife;
                shot.speed.y = shootingSpeed;
                shot.isEnemyShot = isEnemy;
                shot.damage = damage;
                shot.direction = this.transform.up; // ici la droite sera le devant de notre objet
                rotation = rotation + rotate;
            }
        }
    }
    /// <summary>
    /// L'arme est chargée ?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

}
