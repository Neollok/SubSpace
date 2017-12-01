using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour {
    bool withinRange = false;
    public bool triggered = false;

    void Update()
    {
        if (withinRange)
        {
                triggered = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
            withinRange = true;

    }
}
