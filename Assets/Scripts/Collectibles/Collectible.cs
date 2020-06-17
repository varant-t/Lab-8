using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType {
        COIN, LIVES, MUSHROOM, GODMODE }

    public CollectibleType type;


    GameManager instance;
    GameObject player;
    PlayerFire playerFireScript;

    // Start is called before the first frame update
    void Start()
    {
        instance = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            playerFireScript = player.GetComponent<PlayerFire>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           switch (type)
           {
                case CollectibleType.COIN:
                    instance.score++;
                    playerFireScript.projectileSpeed = 8;
                    break;
                case CollectibleType.GODMODE:
                    break;
                case CollectibleType.LIVES:
                    instance.lives++;
             
                    break;
                case CollectibleType.MUSHROOM:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
