using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    
    
    // Update is called once per frame
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             if (pauseMenu.activeInHierarchy == false)
             {
                 pauseMenu.SetActive(true);
                 Time.timeScale = 0;
             }
             else
             {
                 pauseMenu.SetActive(false);
                 Time.timeScale = 1;
             }
        }
       
    }
    
    public void ResumeGame ()
    {
        pauseMenu.SetActive(false);
        
    }
    
  
}
