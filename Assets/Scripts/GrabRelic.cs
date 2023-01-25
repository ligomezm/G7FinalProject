using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabRelic : MonoBehaviour
{
    public GameObject victoryCanvas;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryCanvas.SetActive(true);
            Debug.Log("Congratulations!");

        }
        
    }

    public void  OnVictory()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
