using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject MenuPanel;
    public GameObject HUDPanel;

    private void Awake()
    {
        MenuPanel.SetActive(false);
        HUDPanel.SetActive(false);
    }

    public void ToggleMenu(bool t)
    {
        MenuPanel.SetActive(t);
        HUDPanel.SetActive(!t);
    }
}
