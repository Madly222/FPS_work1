using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static int kills;
    public static int target;
    public static int winCount;
    public static int loseCount;
    public static bool pause = false;

    public TextMeshProUGUI playerLose;
    public TextMeshProUGUI playerWin;

    public GameObject pauseMenuUI;
    public GameObject winMenuUI;
    public GameObject loseMenuUI;


    void Start()
    {
        kills = 0;
    }

    void Update()
    {
        playerLose.text = "Lose:" + loseCount;
        playerWin.text = "Win:" + winCount;

        //win menu
        if(kills == target && Enemy.killed == true)
        {
            Time.timeScale = 0;
            winMenuUI.SetActive(true);
            winCount++;
            kills = 0;
            Cursor.lockState = CursorLockMode.None;
        }

        //pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == true)
            {
                
                PauseOff();
            }
            else
            {
                PauseOn();
            }
        }

        //dead menu
        if (PlayerManager.isGameOver == true)
        {
            loseMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            loseCount++;
            Time.timeScale = 0;
            PlayerManager.isGameOver = false;
        }

    }

    public void Restart()
    {
        target = 0;
        Enemy.killed = false;
        SceneManager.LoadScene("Level");
    }

    public void PauseOff()//resume
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pause = false;
        pauseMenuUI.SetActive(false);
    }

    public void PauseOn()//pause
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        pause = true;
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    //salvare date jucator
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        winCount = data.win;//sau winCount
        loseCount = data.lose;
    }
}
