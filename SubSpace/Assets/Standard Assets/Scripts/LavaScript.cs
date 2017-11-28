using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{

    bool withinRange = false;

    void Update()
    {
        if (withinRange)
        {

            GameObject.Find("player").GetComponent<PlayerMovement>().playerHealth = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        withinRange = true;

    }
    void OnTriggerExit2D(Collider2D other)
    {
        withinRange = false;

    }
}

