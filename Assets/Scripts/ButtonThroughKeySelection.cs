using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonThroughKeySelection : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
  {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }
}
