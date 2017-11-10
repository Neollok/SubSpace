using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    
    public float moveSpeed;

    public Transform currentPoint;
    public Transform[] points;

    public int pointSelection;

	void Start () {
        currentPoint = points[pointSelection];
	}
	
	
	void Update () {
        transform.position = 
            Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        if(transform.position == currentPoint.position)
        {
           
            pointSelection++;
            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }
            currentPoint = points[pointSelection];
        }
	}
}
