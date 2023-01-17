using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum LevelNameType
{
    MAIN, MEZOSOIC, ROME, VIKINGS, MAURICIO, LEVEL2, BAYRON
}

public enum DungeonNameType
{ 
    DUNGEON1, DUNGEON2, DUNGEON3, DUNGEON4
}

public class NPCInteractable : MonoBehaviour
{
    public LevelNameType levelNameType;
    public DungeonNameType dungeonNameType;
    public GameObject dialogueBox;
    GameManager gameManager;
    ManageScenes manageScene;
    string currentScene;
    Animation doorAnimation;

    TMP_Text txt;

    void Start()
    {
        manageScene = ManageScenes.GetInstance();
        gameManager = GameManager.GetInstance();
        currentScene = SceneManager.GetActiveScene().name;
        doorAnimation = GetComponent<Animation>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
            //PlayerInteract.OnRelicChosen?.Invoke(levelNameType);

            if (currentScene == "Museo")
            { 
            PlayerInteract.OnRelicChosen?.Invoke(levelNameType);
        }

            if (currentScene == "Level2")
            {
                txt = dialogueBox.gameObject.transform.GetChild(01).GetComponent<TMP_Text>();
                txt.text = "Door: <br>Interact (E)";
                
                //PlayerInteract.OnDoorChosen?.Invoke(dungeonNameType);
            }

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
        //GameManager.OnStateChanged?.Invoke(PlayerInteract.levelsNames[(int) levelToLoad]);
        ManageScenes.GetInstance().normalLevelLoad();
    }

    public void InteractWithDoor(DungeonNameType dungeonToLoad)
    {
        dialogueBox.SetActive(false);
        doorAnimation.Play();
        Debug.Log("Cambiando de dungeon");
        //Set active new dungeon and deactive current dungeon
    }
}
