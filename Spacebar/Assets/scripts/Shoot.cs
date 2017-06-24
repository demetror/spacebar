using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public int damage = 1;
    public bool isEnemyShot = false;
    public Vector2 speed = new Vector2(5, 5);
    public Vector2 direction = new Vector2(0, -1);
    public float life = 1;

    private Vector2 movement;
    // Update is called once per frame
    void Start () {
        Destroy(gameObject, life);
    }

    void Update()
    {
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }



}
