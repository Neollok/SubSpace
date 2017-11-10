using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChild : MonoBehaviour {

    //Used to make the entity a child of this. Currently only allows player to use it
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log(0);
                collision.transform.parent = transform;
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            collision.transform.parent = null;

        }
    }


}
