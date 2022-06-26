using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 movement;
    private float flipScale;

    [SerializeField] private bool isKeyboard = true;
    [SerializeField] private float moveSpeed;
    

    private void Awake()
    {
        flipScale = transform.localScale.x;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement(isKeyboard);

        FlipSprite();
    }

    private void HandleMovement(bool mode)
    {
        if (isKeyboard)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            //controller stuff
        }
    }

    private void FlipSprite()
    {
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = -flipScale;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = flipScale;
        }
        transform.localScale = characterScale;
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    public void SetStartPosition(Vector2 position)
    {
        transform.position = position;
    }
}
