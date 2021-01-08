using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour // Simply the menu
{
    public GameObject settingsPanel;
   public void StartGame()
   {
       //Application.LoadLevel("Level01");
       SceneManager.LoadScene("Level01");

   }

   public void OpenSettings()
   {
       settingsPanel.SetActive(true);
   }

   public void CloseSettings()
   {
       settingsPanel.SetActive(false);
   }

    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
