using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    [Range(0.0f, 200f)]
    public float horizontalForce;
    [Range(0.0f, 1.0f)]
    public float decay;
    public Bounds bounds;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        rigidbody.AddForce(new Vector2(x * horizontalForce, 0.0f));

        rigidbody.velocity *= (1.0f - decay);
    }

    private void CheckBounds()
    {
        // Left Boundary
        if(transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }

        // Right boundary
        if(transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}
