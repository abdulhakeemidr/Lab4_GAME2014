using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> enemyBulletPool;
    public Queue<GameObject> playerBulletPool;
    public int enemyBulletNumber;
    public int playerBulletNumber;

    private BulletFactory factory;

    void Start()
    {
        enemyBulletPool = new Queue<GameObject>();
        playerBulletPool = new Queue<GameObject>();

        factory = GetComponent<BulletFactory>();
    }

    private void AddBullet(BulletType type = BulletType.ENEMY)
    {
        var temp_bullet = factory.createBullet(type);

        switch(type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(temp_bullet);
                enemyBulletNumber++;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(temp_bullet);
                playerBulletNumber++;
                break;
        }
        
    }

    // This method removes a bullet prefab from the bullet pool
    // and returns a reference to it
    public GameObject GetBullet(Vector2 spawnPosition, BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch(type)
        {
            case BulletType.ENEMY:
                if(enemyBulletPool.Count < 1)
                {
                    AddBullet();
                }

                temp_bullet = enemyBulletPool.Dequeue();
                temp_bullet.transform.position = spawnPosition;
                temp_bullet.SetActive(true);
                break;
            case BulletType.PLAYER:
                Debug.Log("Getting Player Bullet");

                if(playerBulletPool.Count < 1)
                {
                    AddBullet(BulletType.PLAYER);
                }

                temp_bullet = playerBulletPool.Dequeue();
                temp_bullet.transform.position = spawnPosition;
                temp_bullet.SetActive(true);
                break;
        }

        return temp_bullet;
    }

    // This method returns a bullet back into the bullet pool
    public void ReturnBullet(GameObject returnedBullet, BulletType type = BulletType.ENEMY)
    {
        returnedBullet.SetActive(false);

        switch(type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(returnedBullet);
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(returnedBullet);
                break;
        }
    }
}
