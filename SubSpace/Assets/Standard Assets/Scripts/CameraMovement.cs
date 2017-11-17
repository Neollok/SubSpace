using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    //Camera behavior. Might get changed later-

    private GameObject player;          //Player

    //These values determin how far the camera can go. Creates a "box"

    public float xCam;
    public float yCam;

    
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");        //Player = player
	}
	
	
	void LateUpdate () {
        

        gameObject.transform.position = player.transform.position + new Vector3(xCam, yCam, gameObject.transform.position.z);
    }
}
