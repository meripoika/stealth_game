using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    //public void OnColisionEnter(Collision collision)

    //    if (Collision.gameobject.Comparetag("player"))
    //{
    //    Application.Quit();
    //}

    private void Update()
    {
        if (CompareTag("Player"))
        {
            Application.Quit();
        }
    }
}
