using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public GameObject player;
    GameObject finishLine;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        finishLine = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player && finishLine)
        {
            float distanceToFinish = Vector2.Distance(player.transform.position, finishLine.transform.position);

            if (distanceToFinish < 0.2)
            {
                //do something
                Debug.Log("Level Completed");
            }
        }
    }
}
