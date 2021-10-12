using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject enemyBullet;
    public GameObject playerBullet;

    public GameObject createBullet(BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch(type)
        {
            case BulletType.ENEMY:
                temp_bullet = Instantiate(enemyBullet);
                break;
            case BulletType.PLAYER:
                temp_bullet = Instantiate(playerBullet);
                break;
        }

        temp_bullet.transform.parent = transform;
        temp_bullet.SetActive(false);

        return temp_bullet;
    }
}
