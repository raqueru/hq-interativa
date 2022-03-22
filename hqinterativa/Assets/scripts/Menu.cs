using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Menu : MonoBehaviour
{


    private ScreensManager screenManager;

    void Awake()
    {
        screenManager = FindObjectOfType<ScreensManager>();

    }


    public void Choice(string NextScene)
    {
        screenManager.NextScene(NextScene);
    }


    public void Quit()
    {
        screenManager.Quit();
    }
}
