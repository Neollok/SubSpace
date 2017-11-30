using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2Door : MonoBehaviour {

    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    

    void Start()
    {
        currentPoint = points[1];

    }

    // Update is called once per frame
    void Update () {
        if(GameObject.Find("BigPlatform").GetComponent<lvl2Platty>().move)
        {
            transform.position =
               Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        }
        else
        {
            transform.position =
               Vector3.MoveTowards(transform.position, points[0].position, Time.deltaTime * moveSpeed);
        }

    }
}
