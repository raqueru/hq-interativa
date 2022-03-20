using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{

    public string NextScene;

    public string PreviousScene;

    public Frame[] Drawings;
    private int maxDrawings;
    public int currentDrawing;
    private ScreensManager screenManager;

    void Awake()
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

            NextDrawing();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PreviousDrawing();
        }
    }
    void NextDrawing()
    {
        if (currentDrawing < maxDrawings)
        {
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
                    Debug.Log("A");
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
                screenManager.NextScene(NextScene);
            }
        }
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
