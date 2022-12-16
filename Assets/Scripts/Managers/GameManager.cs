using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : Singleton<GameManager>
{
    public static Action OnStateChanged;
    CanvasManager canvasManager;
    ManageScenes sceneManager;
    GameState currentGameState = GameState.BOOT;
    Camera mainCamera;

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
                break;
            case GameState.GAME:
                mainCamera.gameObject.SetActive(false);
                OnStateChanged?.Invoke();
                break;
            case GameState.MUSEUM:
                break;
            case GameState.PAUSE:
                break;
            case GameState.GAMEOVER:
                break;
            case GameState.RESTART:
                break;
            case GameState.VICTORY:
                break;


        }
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
