using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManageScenes : Singleton<ManageScenes>
{
    GameManager gameManager;
    CanvasManager canvasManager;
    void Start()
    {
        gameManager = GameManager.GetInstance();
        canvasManager = CanvasManager.GetInstance();
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to load level: " + levelName);
            return;
        }
        ao.completed += OnLoadOperationComplete;
    }

    public void UnloadLevel(string levelName, int i = 0)
    {
        
        Debug.Log(i);
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to load level: " + levelName);
            return;
        }
        if (i == 0)
            ao.completed += OnUnloadOperationComplete;
        else
            ao.completed += OnUnloadOperationComplete1;
        
    }


    void OnLoadOperationComplete(AsyncOperation ao)
    {
        //controller.CanMove = false;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MemoryGame"));
        
    }
    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        // SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
        Debug.Log("unloaded completed");
    }
    void OnUnloadOperationComplete1(AsyncOperation ao)
    {
        gameManager.CurrentGamestate = GameState.GAME;
        
        Debug.Log("unloaded completed");
        
    }
}
