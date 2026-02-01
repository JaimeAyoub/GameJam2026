using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityUtils;

public class ChangeScene : MonoBehaviour
{
    public float fadeTime;
    public Image imageToFade;
    public Image imgTutorial;
    public RectTransform MainMenu;
    public CanvasGroup TutorialPanel;
    public Image comicImage;

    public enum SceneToChange
    {
        MainMenu,
        Testiiiiiiiiiing,

    };
    //Los indices de las escenas son: 0 es MainMeu, 1 es el nivel y 2 es el Game Over
    void Start()
    {
        //imageToFade.enabled = true;
        //FadeOut();
        if (SceneManager.GetActiveScene().buildIndex == 1) return;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }



    public void SelectSceneT(int sceneIndex)
    {
        Time.timeScale = 1;
        ChangeSceneFunction((SceneToChange)sceneIndex);
    }

    private void ChangeSceneFunction(SceneToChange sceneToChange)
    {
        Time.timeScale = 1;
        switch (sceneToChange)
        {
            case SceneToChange.MainMenu:
                SceneManager.LoadScene(0);
                break;
            case SceneToChange.Testiiiiiiiiiing:
                SceneManager.LoadScene(1);
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }

}