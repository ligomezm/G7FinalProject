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
    string currentScene;
    
    GameManager gameManager;
    ManageScenes manageScene;
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

            if (currentScene == "Museo")
            {
                string relicName = this.name;
                txt = dialogueBox.gameObject.transform.GetChild(01).GetComponent<TMP_Text>();
                txt.text = relicName + ": <br>Interact (E)";
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
        GameManager.OnStateChanged?.Invoke(PlayerInteract.levelsNames[(int)levelToLoad]);
    }

    public void InteractWithDoor(DungeonNameType dungeonToLoad)
    {
        dialogueBox.SetActive(false);
        doorAnimation.Play();
        Debug.Log("Cambiando de dungeon");
        //Set active new dungeon and deactive current dungeon
    }
}