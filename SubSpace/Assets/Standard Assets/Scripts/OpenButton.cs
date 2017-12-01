using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour {
    bool withinRange = false;
    public bool triggered = false;

    void Update()
    {
        if (withinRange)
        {
            if (GameObject.Find("player").GetComponent<PlayerMovement>().usingThing)
            {
                triggered = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
            withinRange = true;

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
            withinRange = false;

    }
}
