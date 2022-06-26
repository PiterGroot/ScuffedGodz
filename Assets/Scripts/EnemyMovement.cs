using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform rotationPoint;
    private Rigidbody2D rb2d;

    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private float moveSpeed = 6;
    [SerializeField] private float minDistToPlayer = 3;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rotationPoint = gameObject.transform.GetChild(0);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > minDistToPlayer)
        {
            rb2d.MovePosition(transform.position + rotationPoint.transform.right * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void HandleRotation()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rotationPoint.rotation = Quaternion.Slerp(rotationPoint.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
