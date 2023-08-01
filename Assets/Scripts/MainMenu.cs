using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayGame()
    {
        PauseMenu.target = 0;
        SceneManager.LoadScene("Level");
    //newgame
    }
    //public void GameLoad()
    //{
    //    
    //}
    public void ExitGame()
    {
        Application.Quit();
    }
}
