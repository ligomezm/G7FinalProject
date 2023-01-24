using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSingleton : Singleton<PlayerSingleton>
{
    bool isPaused = false;
    bool isInGameplay = false;
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
           //Debug.Log("asdasdasd");
           //Scene scene = SceneManager.GetActiveScene();
           //SceneManager.LoadScene("Level2");
        //    ManageScenes.GetInstance().ReloadScene("Level2");
            ManageScenes.GetInstance().ReloadScene("Museo2");

        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = !isPaused;
            GameManager.GetInstance().CurrentGamestate = GameState.PAUSE;
            CanvasManager.GetInstance().SwitchCanvas(CanvasType.PAUSE);
        }
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = !isPaused;
            GameManager.GetInstance().CurrentGamestate = GameState.RESUME;
            CanvasManager.GetInstance().SwitchCanvas(CanvasType.GAMEUI);
        }
    }    
   

  

}
