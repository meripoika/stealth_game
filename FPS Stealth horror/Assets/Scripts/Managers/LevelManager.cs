using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // <-- T�ytyy olla kun k�sitell��n scenej�

public class LevelManager : Singleton<LevelManager>
{
    public SceneReference mainMenu;
    public Level[] levels;


    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(mainMenu);
    }

    public void LoadLevel(SceneReference scene)
    {
        SceneManager.LoadScene(scene);

        if (scene == mainMenu)
        {
            UIManager.Instance.ToggleMenu(true);
        }
        else
        {
            UIManager.Instance.ToggleMenu(false);
        }
    }

    public void LoadLevel(string sceneName)
    {
        foreach (Level level in levels)
        {
            if (sceneName == level.name)
            {
                LoadLevel(level.scene);
                break;
            }
        }
    }
}

[System.Serializable]
public class Level
{
    public string name;
    public SceneReference scene;
}
