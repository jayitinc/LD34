﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Vector2 inputVector;
    private Vector2 movementVector;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float left = 0;
        float right = 0;
        float up = 0;
        float down = 0;

        if (Input.GetKey(KeyCode.W))
            up = 1;
        else
            up = 0;

        if (Input.GetKey(KeyCode.A))
            left = 1;
        else
            left = 0;

        if (Input.GetKey(KeyCode.S))
            down = 1;
        else
            down = 0;

        if (Input.GetKey(KeyCode.D))
            right = 1;
        else
            right = 0;

        inputVector = new Vector2(right - left, up - down).normalized;
        movementVector = inputVector * speed;

        rb.velocity = movementVector;
    }
}