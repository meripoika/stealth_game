using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject MenuPanel;
    public GameObject PausePanel;

    private void Awake()
    {
        MenuPanel.SetActive(false);
        PausePanel.SetActive(false);
}

    public void ToggleMenu(bool t)
    {
        MenuPanel.SetActive(t);
    }

    public void PauseMenu( bool t)
    {
        PausePanel.SetActive(t);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
