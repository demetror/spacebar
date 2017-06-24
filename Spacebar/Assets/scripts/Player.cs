using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {


    public Vector2 speed = new Vector2(50, 50);

    private Vector2 movement;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        // Astuce pour ceux sous Mac car Ctrl + flèches est utilisé par le système
        Shield shield = GetComponentInChildren<Shield>();
        if (Input.GetButton("Fire1"))
        {
            shield.Protect(movement);
        }
        if (Input.GetButton("RotaD"))
        {
            shield.RotaGauche();
        }
        if (Input.GetButton("RotaG"))
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

    private void OnDestroy()
    {
        if (Application.loadedLevel == 1)
            SceneManager.LoadScene(0);  

    }

}

