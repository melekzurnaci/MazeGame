using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 16f;
    public Rigidbody2D myBody;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        Vector2 vel = myBody.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;
        myBody.velocity = vel;
    }
}
