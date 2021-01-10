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
    
    
    public void  Resume()
    { 
                                              
        pauseMenu.SetActive(false);
                                             
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             if (pauseMenu.activeInHierarchy == false)
             {
                 pauseMenu.SetActive(true);
             }
             else
             {
                 pauseMenu.SetActive(false);
             }
        }
       
    }
    
  
}
