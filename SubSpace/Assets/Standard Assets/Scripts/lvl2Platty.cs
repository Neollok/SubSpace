using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2Platty : MonoBehaviour
{


    public float moveSpeed;
    public bool move = false;
    public Transform currentPoint;
    public Transform[] points;

    public int pointSelection;

    void Start() {
        Debug.Log(PlayerPrefs.GetInt("platcheck")); 
        pointSelection = PlayerPrefs.GetInt("platcheck", 0);
        currentPoint = points[pointSelection];
        transform.position = currentPoint.position;
       
    }


    void Update()
    {
        if (move)
        {


            transform.position =
                Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

            if (transform.position == currentPoint.position)
            {
                pointSelection++;
                move = false;
                if (pointSelection == points.Length)
                {
                    pointSelection = 0;
                }
                currentPoint = points[pointSelection];
            }
        }
    }

    
   
}
