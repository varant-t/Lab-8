using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walker : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public int health;

    public float speed;
    

    public bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (!rb)
        {
            Debug.LogWarning("No Rigidbody 2D found...");
        }

        if (!sr)
        {
            Debug.LogWarning("No SpriteRenderer found...");
        }

        if (!anim)
        {
            Debug.LogWarning("No Animator found...");
        }

        if (speed <= 0)
        {
            speed = 5.0f;

            Debug.LogWarning("Speed defaulted to 5");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("Death") && !anim.GetBool("Squish"))
        {
            if (sr.flipX)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
    }

    public void IsDead()
    {
        health--;
        if (health <= 0)
        {
            anim.SetBool("Death", true);
        }
    }

    public void IsSquished()
    {
        anim.SetBool("Squish", true);
    }

    public void FinishDeath()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            sr.flipX = !sr.flipX;
        }
    }
}
