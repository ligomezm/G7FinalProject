using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : Singleton<PlayerSingleton>
{
    bool isPaused = false;
    bool isInGameplay = false;
    LifeBar lifeBar;
    public bool IsInGameplay
    {
        get { return isInGameplay;}
        set 
        {
            AdjustLifeBar();
            isInGameplay = value;
        }
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = !isPaused;
            CanvasManager.GetInstance().SwitchCanvas(CanvasType.PAUSE);
        }
        else if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = !isPaused;
            CanvasManager.GetInstance().SwitchCanvas(CanvasType.GAMEUI);
        }
    }    
    public void EnableLifeBar()
    {
        lifeBar = GetComponent<LifeBar>();
        if (lifeBar != null && !lifeBar.enabled)
        {
            lifeBar.enabled = true;
        }
    }
    public void SetPlayerPosition()
    {
        gameObject.transform.position = new Vector3(0, -0.9f, 0);
    }

    public void AdjustLifeBar()
    {
        lifeBar.SetLinearIndicator();
    }

}
