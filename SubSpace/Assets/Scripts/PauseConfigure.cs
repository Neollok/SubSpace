using UnityEngine;
using System.Collections;



public class PauseConfigure : MonoBehaviour
{

    public Transform canvas;
    public GameObject playerArm;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void Pause()
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                AudioListener.volume = 0;
                playerArm.GetComponent<PointToCursor>().enabled = false;
                playerArm.GetComponent<PlayerShoot>().enabled = false;
                Cursor.visible = true;
        }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                AudioListener.volume = 1;
                playerArm.GetComponent<PointToCursor>().enabled = true;
                playerArm.GetComponent<PlayerShoot>().enabled = true;
        }
        }

    }