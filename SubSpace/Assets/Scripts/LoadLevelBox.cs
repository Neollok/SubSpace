using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelBox: MonoBehaviour
{

    bool withinRange = false;

    public string LevelToLoad;

    void Update()
    {
        if (withinRange)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(LevelToLoad);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "GroundCheck")
            withinRange = true;

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
            withinRange = false;

    }
}

