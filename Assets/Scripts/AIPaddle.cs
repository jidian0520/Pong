﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Ball theBall;

    public float speed = 30;

    public float lerpTweak = 2f;

    private Rigidbody2D _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (theBall.transform.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0, 1).normalized;

            _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, dir * speed, lerpTweak * Time.time);
        }
        else if (theBall.transform.position.y < transform.position.y)
        {
            Vector2 dir = new Vector2(0, -1).normalized;

            _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, dir * speed, lerpTweak * Time.time);
        }
        else
        {
            Vector2 dir = new Vector2(0, 0).normalized;
            _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, dir * speed, lerpTweak * Time.time);
        }
    }
}
