using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    //Used to activate mag boots. UNFINISHED
    //Will add animations or smth 

    private RaycastHit2D hit;
    public Transform particles;
    public LayerMask whatNotToHit;
    private bool spawned = false;

    void Start () {
       
	}
	
	
	void Update () {
       
        hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.7f, 0), Vector2.up*10);

       
        
        if (hit.collider.tag == "Ground")
        {
            if (hit.distance <= 3)
            {
                if (Input.GetKey("space"))
                    Debug.Log("Activate boots");

                if (GameObject.Find("Mag boot Effect(Clone)") == null)
                {
         
                    Instantiate(particles, transform.position, transform.rotation);
                }
            }


        }
        if (hit.distance > 3 && GameObject.Find("Mag boot Effect(Clone)") != null)
        {
            
            Destroy(GameObject.Find("Mag boot Effect(Clone)"));
        }
    }
}
