using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("BossMob1").GetComponent<BossScript>().posY = other.transform.position.y;
        }
    }
}
