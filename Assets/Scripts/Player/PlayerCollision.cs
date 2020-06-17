using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D myRigidBody;

    public float bounceForce;
    Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Transform>();

        if (bounceForce <= 0)
        {
            bounceForce = 20.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -5.3)
        {
            GameManager.instance.lives -= 1;
            GameManager.instance.SpawnPlayer(spawnPoint);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            GameManager.instance.lives -= 1;
            GameManager.instance.SpawnPlayer(spawnPoint);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemySquish")
        {
            collision.gameObject.GetComponentInParent<Enemy_Walker>().IsSquished();

            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(Vector2.up * bounceForce);
        }
    }


}
