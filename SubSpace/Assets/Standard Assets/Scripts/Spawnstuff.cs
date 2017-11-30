using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnstuff : MonoBehaviour {
    bool Spawned = true;
    public bool withinRange = false;
    public Transform[] SpawnLocation;
    public GameObject[] Prefab;
    public GameObject[] Spawn;
    public int SpawnAmount;

	void Update(){
        if (withinRange) {
            if (Spawned) {
            SpawnTheThings();
                Spawned = false;
             }
        }
    }
	

	void SpawnTheThings() { 
        for(int x=0; x<SpawnAmount; x++) {
            Spawn[x] = Instantiate(Prefab[x], SpawnLocation[x].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
            withinRange = true;

    }
}
