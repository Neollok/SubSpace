using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingArea : MonoBehaviour
{
    //public float sizeX = 1;
    //public float sizeY = 1;
    public bool health = false;
    public bool kill = false;
    public BoxCollider2D col;

    // Use this for initialization
    void Start()
    {
        //col.size = new Vector2(sizeX, sizeY);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            GameObject player = GameObject.Find("player");
            if (!kill && !health)
            {
                player.GetComponent<PlayerMovement>().playerHealth--;
            }
            else if (kill && !health)
            {
                player.GetComponent<PlayerMovement>().playerHealth = 0;

            }
            else if (!kill && health)
            {
                player.GetComponent<PlayerMovement>().playerHealth++;
            }
            else // kill and health, full health
            {
                player.GetComponent<PlayerMovement>().playerHealth = 3;
            }
        }
    }
}
