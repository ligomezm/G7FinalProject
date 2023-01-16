using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    // public static Dictionary<int, string> levelsToLoadDictionary = new Dictionary<int, string>();
    public static Action<LevelNameType> OnRelicChosen;
    public static Action<DungeonNameType> OnDoorChosen;

    private LevelNameType interactedRelicType;
    private DungeonNameType interactedDoorType;

    public static string[] levelsNames = {"main", "Mezosoic", "Rome", "Vikings", "Mauricio", "Level2"};
    public static string[] dungeonsNames = {"Dungeon1", "Dungeon2", "Dungeon3", "Dungeon4"};

    public Inventory inventory;
    TMP_Text txt;

    GoldKeyCollectable goldKey;
    public const string Door = "Door";
    public const string NewTxtUI = "You need a key to open";

    void OnEnable()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        goldKey = FindObjectOfType<GoldKeyCollectable>();

        OnRelicChosen += InteractionRelic;
        OnDoorChosen += InteractionDoor;
    }

    void OnDisable()
    {
        OnRelicChosen -= InteractionRelic;
        OnDoorChosen -= InteractionDoor;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            Debug.Log(colliderArray.Length);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable nPCInteractable)
                    && collider.gameObject.CompareTag(Door))
                {
                    if(inventory.ItemInInventory(goldKey))
                    { 
                        nPCInteractable.InteractWithDoor(nPCInteractable.dungeonNameType);
                        int itemKeyInInventory = inventory.GetKeyFromValue(goldKey);
                        inventory.RemoveItem(goldKey, itemKeyInInventory);
                        //remover llave de inventario
                    }
                    else
                    {
                        txt = collider.gameObject.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
                        txt.text = NewTxtUI;
                    }
                }

                else if (collider.TryGetComponent(out NPCInteractable npcInteractable) 
                    && collider.gameObject.GetComponent<NPCInteractable>().levelNameType == interactedRelicType)
                {
                    Debug.Log(npcInteractable.levelNameType);
                    npcInteractable.Interact(npcInteractable.levelNameType);
                }

            }
        }
    }

    private void InteractionRelic(LevelNameType levelNameType)
    {
        interactedRelicType = levelNameType;
    }

    private void InteractionDoor(DungeonNameType dungeonNameType)
    {
        interactedDoorType = dungeonNameType;
    }

    
}
