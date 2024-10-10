using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float lBound;
    [SerializeField] private float rBound;
    private bool isRight;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        isRight = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            moveRight();
        }
        else
        {
            moveLeft();
        }

        if (transform.position.x >= rBound)
        {
            isRight = false;
        }

        if (transform.position.x <= lBound)
        {
            isRight = true;
        }
    }

    void moveRight()
    {
        spriteRenderer.flipX = false;
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void moveLeft()
    {
        spriteRenderer.flipX = true;
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
