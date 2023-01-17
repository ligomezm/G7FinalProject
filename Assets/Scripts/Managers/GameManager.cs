using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static Action<string> OnStateChanged;
    CanvasManager canvasManager;
    ManageScenes sceneManager;
    GameState currentGameState = GameState.BOOT;
    Camera mainCamera;
    [SerializeField] EventSystem eventSystem;

    void Start()
    {
        canvasManager = CanvasManager.GetInstance();
        sceneManager = ManageScenes.GetInstance();
        mainCamera = Camera.main;
    }
    void UpdateState(GameState state)
    {
        switch(currentGameState)
        {
            case GameState.BOOT:
                
                break;
            case GameState.MAINMENU:
                 mainCamera.gameObject.SetActive(true);
                SetTimeScale(1);
                break;
            case GameState.GAME:
                //mainCamera.gameObject.SetActive(false);
                //OnStateChanged?.Invoke();
                //eventSystem.gameObject.SetActive(false);
                
                SetTimeScale(1);
                break;
            case GameState.MUSEUM:
                eventSystem.gameObject.SetActive(false);
                mainCamera.gameObject.SetActive(false);
                sceneManager.LoadLevel("Museo");
                SetTimeScale(1);
                break;
            case GameState.PAUSE:
                SetTimeScale(0);
                break;
            case GameState.GAMEOVER:
                break;
            case GameState.RESTART:
                break;
            case GameState.VICTORY:
                break;
            case GameState.RESUME:
                SetTimeScale(1);
                break;


        }
    }
    private void SetTimeScale(int t)
    {
        if (t == 1 || t == 0)
            Time.timeScale = t;
        return;
    }


    public GameState CurrentGamestate
    {
        get {return currentGameState;}
        set
        {
            currentGameState = value;
            UpdateState(currentGameState);
        }
    }
}
