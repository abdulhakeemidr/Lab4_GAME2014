using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public BulletType type;

    [Header("Bullet Movement")]
    [Range(0.0f, 0.5f)]
    public float speed;
    public Bounds bulletBounds;
    public BulletDirection bulletDirection;

    private BulletManager bulletManager;
    private Vector3 velocity;

    void Start()
    {
        bulletManager = GameObject.FindObjectOfType<BulletManager>();

        switch(bulletDirection)
        {
            case BulletDirection.UP:
                velocity = new Vector3(0.0f, speed, 0.0f);
                break;
            case BulletDirection.RIGHT:
                velocity = new Vector3(speed, 0.0f, 0.0f);
                break;
            case BulletDirection.DOWN:
                velocity = new Vector3(0.0f, -speed, 0.0f);
                break;
            case BulletDirection.LEFT:
                velocity = new Vector3(-speed, 0.0f, 0.0f);
                break;
        }
    }

    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {

        transform.position += velocity;
    }

    private void CheckBounds()
    {
        // checks bottom bounds
        if(transform.position.y < bulletBounds.max)
        {
            // returns the bullet to the cue when it leaves the screen
            bulletManager.ReturnBullet(this.gameObject, type);
        }

        // checks top bounds
        if (transform.position.y > bulletBounds.min)
        {
            // returns the bullet to the cue when it leaves the screen
            bulletManager.ReturnBullet(this.gameObject, type);
        }
    }
}
