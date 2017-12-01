using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayer : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("BossMob1").GetComponent<BossScript>().posY = other.transform.position.y - transform.position.y;
        }
    }
}
