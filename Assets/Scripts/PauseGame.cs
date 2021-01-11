using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField]  GameObject pauseMenu;
    [SerializeField]  GameObject optionMenu;
    FMOD.Studio.Bus General;
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus Sfx;
    FMOD.Studio.EventInstance seTestEvent;
   private float _musicVolume = 0.5f;
   private float _sfxVolume = 0.5f;
   private float _generalVolume = 1f;
    
    // Update is called once per frame
    private void Awake()
    {
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        Sfx = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        General = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        seTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Spells/PlayerSpell");
    }

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
                optionMenu.SetActive(false);
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }

        Music.setVolume(_musicVolume);
        Sfx.setVolume(_sfxVolume);
        General.setVolume(_generalVolume);
    }

    public void GeneralVolumeLevel(float newGeneralVolume)
    {
        _generalVolume = newGeneralVolume;
    }
 
    public void MusicVolumeLevel(float newMusicVolume)
    {
        _musicVolume = newMusicVolume;
    }
 
    public void SfxVolumeLevel(float newsfxVolume)
    {
        _sfxVolume = newsfxVolume;
        FMOD.Studio.PLAYBACK_STATE pbState;
        seTestEvent.getPlaybackState(out pbState);
        if (pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            seTestEvent.start();
        }
        
    }
    
    public void Options ()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
        optionMenu.SetActive(true);
        
    }
    
    public void Return ()
    {
        optionMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    
    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
  
}
