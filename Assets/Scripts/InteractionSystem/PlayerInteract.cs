using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // public static Dictionary<int, string> levelsToLoadDictionary = new Dictionary<int, string>();
    public static Action<LevelNameType> OnRelicChosen;
    private LevelNameType interactedRelicType;
    public static string[] levelsNames = {"main", "Mezosoic", "Rome", "Vikings", "Mauricio"};
    
    void OnEnable()
    {
        OnRelicChosen += InteractionRelic;
    }

    void OnDisable()
    {
        OnRelicChosen -= InteractionRelic;
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
                if (collider.TryGetComponent(out NPCInteractable npcInteractable) && collider.gameObject.GetComponent<NPCInteractable>().levelNameType == interactedRelicType)
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
    
}
