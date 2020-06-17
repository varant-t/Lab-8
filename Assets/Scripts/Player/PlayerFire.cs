using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public SpriteRenderer marioSprite;

    public Transform spawnPointRight;
    public Transform spawnPointLeft;

    public float projectileSpeed;
    public Projectile projectilePrefab;



    // Start is called before the first frame update
    void Start()
    {
        if (projectileSpeed <= 0)
        {
            projectileSpeed = 7.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        

        if (marioSprite.flipX)
        {
            Projectile temp = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            temp.speed = -projectileSpeed;
        }
        else
        {
            Projectile temp = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            temp.speed = projectileSpeed;
        }
    }
}
