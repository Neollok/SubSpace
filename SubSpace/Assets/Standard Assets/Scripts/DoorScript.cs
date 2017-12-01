using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public float moveSpeed;
    public Transform[] points;
    public GameObject[] CloseB;
    public GameObject[] OpenB;
    public bool Closed = false;
    bool unused=true, unused1=true;

    private void Start()
    {
        Closed = false;
    }
    // Update is called once per frame
    void Update() {
        if(CloseB[0].GetComponent<CloseButton>().triggered)
        {
            Debug.Log("...");
            if(unused)
            { 
            Closed = true;
            unused = false;
            }
        }

        if (OpenB[0].GetComponent<OpenButton>().triggered)
        {
            Debug.Log("...");
            if (unused1)
            {
                Closed = false;
            unused1 = false;
            }
        }

        if (Closed)
        {
            
            transform.position =
               Vector3.MoveTowards(transform.position, points[1].position, Time.deltaTime * moveSpeed);
            
        }
        else
        {
            
            transform.position =
               Vector3.MoveTowards(transform.position, points[0].position, Time.deltaTime * moveSpeed);
            
        }
        
    }
}
