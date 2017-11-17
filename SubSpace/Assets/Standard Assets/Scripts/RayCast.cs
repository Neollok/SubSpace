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
    public bool canChange = true;

    void Start () {
       
	}
	
	
	void Update () {
       
        hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.7f, 0), Vector2.up*10);

       
        
        if (hit.collider.tag == "Ground")
        {
            if (hit.distance <= 3)
            {
                if (Input.GetKeyDown("space") && canChange && !GetComponent<PlayerMovement>().wallJumpActive)
                {
                    GetComponent<PlayerMovement>().changeGravity = true;
                    canChange = false;
                }
                    

                if (GameObject.Find("Mag boot Effect(Clone)") == null)
                {
                    Debug.Log("Making effect");
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
