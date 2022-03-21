using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Screen : MonoBehaviour
{

    public string NextScene;

    public string PreviousScene;

    public Frame[] Drawings;

    private int maxDrawings;
    public int currentDrawing;
    public bool choice;
    private ScreensManager screenManager;

    async void Awake()
    {
        screenManager = FindObjectOfType<ScreensManager>();
        maxDrawings = Drawings.Length;


        if (!screenManager.returned)
        {
            currentDrawing = 0;
            NextDrawing();
        }
        else
        {
            for (int i = 0; i < maxDrawings; i++)
            {

                NextDrawing();
            }
        }

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {


            if (!choice)
            {
                NextDrawing();
            }


        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!choice)
            {
                PreviousDrawing();
            }

        }
    }
    void NextDrawing()
    {
        if (currentDrawing < maxDrawings)
        {
            if (Drawings[currentDrawing].choice)
            {
                choice = true;
            }
            Drawings[currentDrawing].gameObject.SetActive(true);
            if (Drawings[currentDrawing].animated)
            {
                if (!Drawings[currentDrawing].played)
                {

                    Drawings[currentDrawing].Play();
                    Drawings[currentDrawing].played = true;


                }
                else
                {
                    Drawings[currentDrawing].gameObject.SetActive(false);

                    currentDrawing++;


                    NextDrawing();


                }
            }
            else
            {
                currentDrawing++;
            }


        }
        else
        {
            if (NextScene != "")
            {
                GoToNextScene(NextScene);
            }
        }
    }


    public void GoToNextScene(string NextScene)
    {
        screenManager.NextScene(NextScene);
    }
    void PreviousDrawing()
    {
        if (currentDrawing > 0)
        {
            Drawings[currentDrawing].gameObject.SetActive(false);
            Drawings[currentDrawing].Stop();
            Drawings[currentDrawing].played = false;
            currentDrawing--;
            Drawings[currentDrawing].gameObject.SetActive(true);

            Drawings[currentDrawing].Play();

        }
        else
        {
            if (PreviousScene != "")
            {
                screenManager.PreviousScene(PreviousScene);
            }
        }

    }


    public void Choice(string NextScene)
    {
        screenManager.NextScene(NextScene);
    }
}
