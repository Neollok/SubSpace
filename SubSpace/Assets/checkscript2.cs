using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkscript2 : MonoBehaviour
{

    public bool check = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CheckpointScript>().playerPassed && !check)
        {
            check = true;
            PlayerPrefs.SetInt("platcheck", 4);
        }
    }
}
