using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerMovement Player;

    bool isPaused = false;

    public void PauseGame()
    {
        if (isPaused)
            PauseGame(false);
        else
            PauseGame(true);
    }

    void PauseGame(bool t)
    {
        if (t)
        {
            Time.timeScale = 0;
            UIManager.Instance.PauseMenu(true);
            isPaused = true;
            Player.canMove = false;
            Player.pCamera.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
             UIManager.Instance.PauseMenu(false);
            isPaused = false;
            Player.canMove = true;
            Player.pCamera.enabled = true;
        }
    }
}
