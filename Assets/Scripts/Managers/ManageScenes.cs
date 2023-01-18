using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class ManageScenes : Singleton<ManageScenes>
{
    public static Action OnSceneLoaded;
    GameManager gameManager;
    CanvasManager canvasManager;
    string currentLevelName;
    GameObject playerObject;
    void Start()
    {
        gameManager = GameManager.GetInstance();
        canvasManager = CanvasManager.GetInstance();
        currentLevelName = SceneManager.GetActiveScene().ToString();
    }

    void OnEnable()
    {
        GameManager.OnStateChanged += ChangeLevel;
    }
    void OnDisable()
    {
        GameManager.OnStateChanged -= ChangeLevel;
    }

    public void ChangeLevel(string level)
    {
        LoadLevel(level);
    }

    // public void ChangeMuseumLevel(string level)
    // {
    //     if (gameManager.CurrentGamestate == GameState.MUSEUM)
    //     {
    //         LoadLevel(level, 1);
    //     }
    // }
    string placeholder;
    
    public void LoadLevel(string levelName, int loadOperation = 0)
    {
        Scene mainPersistenScene = SceneManager.GetSceneByName("MainMenu");
        placeholder = currentLevelName;
        currentLevelName = levelName;
        try
        {
            playerObject = GameObject.FindGameObjectWithTag("ParentPlayer");

        }
        catch (System.Exception)
        {
            playerObject = null;
        }
        if (playerObject != null) { 
            SceneManager.MoveGameObjectToScene(playerObject, mainPersistenScene);
        }
        else
        {
            playerObject = GameObject.FindGameObjectWithTag("ParentPlayer");

        }

        AsyncOperation ao;
        ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        if (ao == null)
        {
            Debug.LogError("[GameManager] unable to load level: " + levelName);
            return;
        }
        if (placeholder == "Museo")
        {
            // FindObjectOfType<PlayerInput>().gameObject.SetActive(false);
            UnloadLevel("Museo", 1);
        }

        ao.completed += OnLoadOperationComplete;
    }

    public void UnloadLevel(string levelName, int i = 0)
    {


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
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelName));
        if (playerObject != null)
            SceneManager.MoveGameObjectToScene(playerObject, SceneManager.GetActiveScene());
        if (SceneManager.GetActiveScene().name != "Museo")
        {
            OnSceneLoaded?.Invoke();
            PlayerSingleton.GetInstance().EnableLifeBar();
            PlayerSingleton.GetInstance().IsInGameplay = true;
            playerObject.GetComponentInChildren<PlayerSingleton>().transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
        }
        // if (currentLevelName != "Museo")
        //     PlayerSingleton.GetInstance().SetPlayerPosition();


    }
    void OnUnloadOperationComplete(AsyncOperation ao)
    {

    }
    void OnUnloadOperationComplete1(AsyncOperation ao)
    {
        gameManager.CurrentGamestate = GameState.GAME;



    }
}