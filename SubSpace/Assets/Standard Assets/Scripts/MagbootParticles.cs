using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagbootParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.parent = GameObject.Find("player").transform;

    }
	
	
	void Update () {
		
	}
}
