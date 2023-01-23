using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    public DungeonNameType dungeonNameType;
    private DungeonManager dungeonManager;

    public void Init(DungeonManager _dungeonManager)
    {
        dungeonManager = _dungeonManager;
    }
    void OnEnable()
    {
        if (dungeonNameType == DungeonNameType.DUNGEON0)
            return;
        DungeonManager.dungeons.Add(this);
    }

    // void OnDisable()
    // {
    //     DungeonManager.dungeons.Remove(this);
    // }
}
