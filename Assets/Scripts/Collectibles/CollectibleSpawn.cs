using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawn : MonoBehaviour
{

    public GameObject coinPrefab;
    public GameObject lifePrefab;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            Instantiate(coinPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
        else if (random == 1)
        {
            Instantiate(lifePrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
