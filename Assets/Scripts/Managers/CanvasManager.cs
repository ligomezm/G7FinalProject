using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;
    public CanvasType initialCanvasType;
    [SerializeField] FadeScreenBehavior fade;
    protected override void Awake()
    {
            base.Awake();
            canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
            canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
            SwitchCanvas(initialCanvasType);
    }

        public void SwitchCanvas(CanvasType _type)
        {
            if (lastActiveCanvas != null)
                lastActiveCanvas.gameObject.SetActive(false);
            CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
            if (desiredCanvas != null)
            {
                desiredCanvas.gameObject.SetActive(true);
                lastActiveCanvas = desiredCanvas;
            }
            else
                Debug.LogWarning("The desired canvas was not found");
        }

    public void ScreenFade()
    {
        fade.FadeIn();
    }
}
