using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public Transform healthBarPrefab;
    public float maxHealth;
    public float lastHealth;
    public float currentHealth;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        lastHealth = currentHealth;

        Transform hpBar = (Transform)Instantiate(healthBarPrefab, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        hpBar.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update () {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
		if(lastHealth > currentHealth)
        {
            //Display new health bar
            
            lastHealth = currentHealth;
        }
	}
}
