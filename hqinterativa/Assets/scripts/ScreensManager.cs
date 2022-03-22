using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class ScreensManager : MonoBehaviour
{
    private static bool screenManagerExists = false;
    public bool returned = false;
    void Start()
    {
        ScreensManager screenmanager = FindObjectOfType<ScreensManager>();
        if (!screenManagerExists) //if GameManagerexcistst is not true --> this action will happen.
        {
            screenManagerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }






    public void NextScene(string SceneName)
    {
        returned = false;
        SceneManager.LoadScene(SceneName);
    }
    public void PreviousScene(string SceneName)
    {
        returned = true;
        SceneManager.LoadScene(SceneName);
    }


    public void Quit()
    {
        Application.Quit();
    }

}
