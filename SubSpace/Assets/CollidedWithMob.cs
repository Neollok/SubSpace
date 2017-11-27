using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidedWithMob : MonoBehaviour {
    public float timeNotGetHurt = 1;
    float timer;
    bool loopRunning = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (loopRunning)
        {
            timer += Time.deltaTime; // adds time past to counter
            if (timer >= timeNotGetHurt)
            {
                loopRunning = false;
                timer = 0;
            }
        }

    }
}
