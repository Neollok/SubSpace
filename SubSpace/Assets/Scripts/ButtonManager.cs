﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void NewGameBtn(string NewGameLevel)
    {
        PlayerPrefs.DeleteAll();    
        SceneManager.LoadScene(NewGameLevel);
        Time.timeScale = 1;
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}