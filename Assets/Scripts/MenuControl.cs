using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public void LoadLevel(int levelToLoad)
    {
        Time.timeScale = 1;
        LevelManager.Instance.ManagerLoadLevel(levelToLoad);
    }

    public void ResetLevel()
    {
        LevelManager.Instance.Restart();
    }

    public void ExitGame()
    {
        LevelManager.Instance.ExitGame();
    }
}
