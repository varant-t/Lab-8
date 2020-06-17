using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Transform cameraBoundMin;

    public Transform cameraBoundMax;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        xMin = cameraBoundMin.position.x;
        yMin = cameraBoundMin.position.y;

        xMax = cameraBoundMax.position.x;
        yMax = cameraBoundMax.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), 
                                            Mathf.Clamp(target.position.y, yMin, yMax), 
                                            transform.position.z);
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("CameraTarget").GetComponent<Transform>();
        }
    }
}
