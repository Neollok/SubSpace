using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hbBarScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        float x = transform.parent.GetComponent<HealthScript>().currentHealth / transform.parent.GetComponent<HealthScript>().maxHealth;

        transform.localScale = new Vector3(x, 0.2f, 1);
	}
}
