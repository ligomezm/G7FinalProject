using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelNameType
{
    MAIN, MEZOSOIC, ROME, VIKINGS, MAURICIO, LEVEL2, 
}
public class NPCInteractable : MonoBehaviour
{
    public LevelNameType levelNameType;
    public GameObject dialogueBox;
    GameManager gameManager;
    ManageScenes manageScene;
    void Start()
    {
        manageScene = ManageScenes.GetInstance();
        gameManager = GameManager.GetInstance();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
            PlayerInteract.OnRelicChosen?.Invoke(levelNameType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(false);
        }
    }

    public void Interact(LevelNameType levelToLoad)
    {
        
        //manageScene.ChangeMuseumLevel(PlayerInteract.levelsNames[(int)levelToLoad]);
        gameManager.CurrentGamestate = GameState.GAME;
        GameManager.OnStateChanged?.Invoke(PlayerInteract.levelsNames[(int) levelToLoad]);
    }
}
