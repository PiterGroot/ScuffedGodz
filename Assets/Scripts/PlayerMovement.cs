using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 movement;
    private float flipScale;
    private string[] inputMode = new string[2];

    [SerializeField] private bool isKeyboard = true;
    [SerializeField] private float moveSpeed;
    
    private void Awake()
    {
        flipScale = transform.localScale.x;
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        inputMode[0] = isKeyboard ? "Horizontal" : "HorizontalController";
        inputMode[1] = isKeyboard ? "Vertical" : "VerticalController";
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        movement.x = Input.GetAxisRaw(inputMode[0]);
        movement.y = Input.GetAxisRaw(inputMode[1]);
    }

    private void FlipSprite()
    {
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis(inputMode[0]) > 0)
        {
            characterScale.x = -flipScale;
        }
        if (Input.GetAxis(inputMode[0]) < 0)
        {
            characterScale.x = flipScale;
        }
        transform.localScale = characterScale;
    }

    private void FixedUpdate()
    {
        FlipSprite();
        rb2D.MovePosition(rb2D.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    public void SetStartPosition(Vector2 position)
    {
        transform.position = position;
        
    }
}
