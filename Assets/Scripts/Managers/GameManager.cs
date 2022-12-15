using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    CanvasManager canvasManager;
    ManageScenes sceneManager;
    GameState currentGameState = GameState.BOOT;

    void Start()
    {
        canvasManager = CanvasManager.GetInstance();
        sceneManager = ManageScenes.GetInstance();
    }
    void UpdateState(GameState state)
    {
        switch(currentGameState)
        {
            case GameState.BOOT:
                
                break;
            case GameState.MAINMENU:
                break;
            case GameState.GAME:
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
