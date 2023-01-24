using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    // public static Dictionary<int, string> levelsToLoadDictionary = new Dictionary<int, string>();
    public static Action<LevelNameType> OnRelicChosen;
    public static Action<DungeonNameType> OnDoorChosen;

    private LevelNameType interactedRelicType;
    private DungeonNameType interactedDoorType;

    public static string[] levelsNames = { "main", "Mezosoic", "Rome", "Vikings", "Mauricio", "Level2", "Bayron", "Level2DungeonTest" };
    public static string[] dungeonsNames = { "Dungeon1", "Dungeon2", "Dungeon3", "Dungeon4" };

    public Inventory inventory;
    public TakeSword takeSword;
    public GameObject museumDoor;

    TMP_Text txt;
    Animation museumDoorAnimation;
    bool museumDoorIsClosed;

    GameObject canvasInstructions;
    GameObject canvasInstructionsII;
    Button button;

    //GoldKeyCollectable goldKey;
    IInventoryItem goldkey;
    public const string Door = "Door";
    public const string NewTxtDoorLevel2 = "You need a key to open";
    public const string NewTxtRelicMuseum = "Get a sword <br>first";

    void OnEnable()
    {
        takeSword = GameObject.FindObjectOfType<TakeSword>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        //goldKey = FindObjectOfType<GoldKeyCollectable>();
        museumDoorAnimation = museumDoor.GetComponent<Animation>();

        OnRelicChosen += InteractionRelic;
        OnDoorChosen += InteractionDoor;
        ManageScenes.OnSceneLoaded += GetReferences;
        museumDoorIsClosed = true;
        CollectItem.OnitemPickup += SetPickedGoldKey;
    }


    void OnDisable()
    {
        OnRelicChosen -= InteractionRelic;
        OnDoorChosen -= InteractionDoor;
        ManageScenes.OnSceneLoaded -= GetReferences;
        CollectItem.OnitemPickup -= SetPickedGoldKey;
    }

    void SetPickedGoldKey(IInventoryItem item) => goldkey = item;

    private void GetReferences()
    {
        goldkey = FindObjectOfType<GoldKeyCollectable>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    

    private void Update()
    {
        // if (SceneManager.GetActiveScene().buildIndex == 3) return;
        InteractWithKeyDown();
        if (inventory == null)
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        else
            return;
        // if (goldKey == null)
        //     goldKey = FindObjectOfType<GoldKeyCollectable>();
            
        //InteractingWithInstructions();
    }

    private void InteractionRelic(LevelNameType levelNameType)
    {
        interactedRelicType = levelNameType;
    }
    
    private void InteractionDoor(DungeonNameType dungeonNameType)
    {
        interactedDoorType = dungeonNameType;
    }

    public void InteractWithKeyDown()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable nPCInteractable)
                    && collider.gameObject.CompareTag(Door))
                {
                    TryToOpenDoor(nPCInteractable, collider);
                }

                else if (collider.TryGetComponent(out NPCInteractable npcInt) && collider.gameObject.name == "Book")
                {
                    ShowInstructions(collider);
                    if (museumDoorIsClosed)
                    { 
                        museumDoorAnimation.Play();
                        museumDoorIsClosed = false;
                    }
                }
                
                else if (collider.TryGetComponent(out NPCInteractable npcInteractable)
                    && collider.gameObject.GetComponent<NPCInteractable>().levelNameType == interactedRelicType)
                {

                    if (takeSword.playerHasSword)
                    {
                        npcInteractable.Interact(npcInteractable.levelNameType);
                    }
                    else
                    {
                        txt = collider.gameObject.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
                        txt.text = NewTxtRelicMuseum;
                    }
                }
            }
        }
    }

    void ShowInstructions(Collider collider)
    {
        SetCursorState(false);
        
        canvasInstructions = collider.transform.GetChild(1).gameObject;
        canvasInstructionsII = collider.transform.GetChild(2).gameObject;
        
        canvasInstructions.SetActive(true);
                
        button = canvasInstructions.transform.GetChild(0).GetChild(0).GetComponent<Button>();
        button.onClick.AddListener(InteractingWithInstructions);
    }

    void InteractingWithInstructions()
    {
            if (canvasInstructions.activeInHierarchy)
            {
                canvasInstructions.SetActive(false);
                canvasInstructionsII.SetActive(true);
                button = canvasInstructionsII.transform.GetChild(0).GetChild(0).GetComponent<Button>();
                button.onClick.AddListener(InteractingWithInstructions);
        }
            else
            {
                canvasInstructionsII.SetActive(false);
                SetCursorState(false);
            }
    }

    void TryToOpenDoor(NPCInteractable nPCInteractable, Collider collider)
    {
        //inventory.mItems.Add(goldKey);
        //inventory.AddItem(goldkey);
        if (inventory.ItemInInventory(goldkey) && inventory.mItems.Contains(goldkey))
        {
            int itemKeyInInventory = inventory.GetKeyFromValue(goldkey);
            nPCInteractable.InteractWithDoor(nPCInteractable.dungeonNameType);
            inventory.RemoveItem(goldkey, itemKeyInInventory);
        }
        else
        {
            txt = collider.gameObject.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
            txt.text = NewTxtDoorLevel2;
        }
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
