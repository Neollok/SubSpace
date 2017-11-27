using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    bool withinRange = false;

    void Update()
    {
        if(withinRange)
        {
            if(GameObject.Find("player").GetComponent<PlayerMovement>().usingThing)
            {
                GameObject.Find("BigPlatform").GetComponent<lvl2Platty>().move = true;
            }
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
