using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : Singleton<PlayerSingleton>
{
    void Update()
    {
        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Escape))
            CanvasManager.GetInstance().SwitchCanvas(CanvasType.PAUSE);
    }    
}
