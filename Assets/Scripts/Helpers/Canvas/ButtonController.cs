using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
        public ButtonType buttonType;

        CanvasManager canvasManager;
        GameManager gameManager;
        Button menuButton;

        void Start()
        {
            menuButton = GetComponent<Button>();
            menuButton.onClick.AddListener(OnButtonClick);
            canvasManager = CanvasManager.GetInstance();
            gameManager = GameManager.GetInstance();
        }

        private void OnButtonClick()
        {
            switch(buttonType)
            {
                case ButtonType.PREGAME:
                    canvasManager.SwitchCanvas(CanvasType.MAINMENU);
                    break;
                case ButtonType.MAINMENU:
                    Debug.Log("button has been pressed");
                    canvasManager.SwitchCanvas(CanvasType.MAINMENU);
                    // UnmountScene
                    break;
                case ButtonType.START:
                    canvasManager.SwitchCanvas(CanvasType.MUSEUM);
                    gameManager.CurrentGamestate = GameState.MUSEUM;
                    break;
                case ButtonType.PAUSE:
                    canvasManager.SwitchCanvas(CanvasType.PAUSE);
                    gameManager.CurrentGamestate = GameState.PAUSE;
                    break;
                case ButtonType.RESTART:
                    canvasManager.SwitchCanvas(CanvasType.GAMEUI);
                    break;
                case ButtonType.RESUME:
                    canvasManager.SwitchCanvas(CanvasType.GAMEUI);
                    gameManager.CurrentGamestate = GameState.RESUME;
                    break;
                case ButtonType.OPTIONS:
                    canvasManager.SwitchCanvas(CanvasType.OPTIONS);
                    break;
                case ButtonType.PAUSEOPTIONS:
                    canvasManager.SwitchCanvas(CanvasType.PAUSEOPTIONS);
                    break;
                case ButtonType.INTRO:
                    canvasManager.SwitchCanvas(CanvasType.INTRO);
                    break;
                case ButtonType.NULL:
                break;                    
                case ButtonType.QUIT:
                    // canvasManager.SwitchCanvas(CanvasType.PAUSEOPTIONS);
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.ExitPlaymode();
                    //UnityEditor.EditorApplication.isPlaying = false;
                #endif
                    Application.Quit();
                    break;
                default:
                    break;
            }
        }
}
