using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static List<Dungeon> dungeons = new List<Dungeon>();
    [SerializeField] Dungeon starterDungeon;
    static Dungeon currentDungeon;

    void Start()
    {
        StartCoroutine(DeactivateDungeonsOnLoad());
    }

    IEnumerator DeactivateDungeonsOnLoad()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Dungeons count: " + dungeons.Count);
        // for (int i = 0; i < dungeons.Count; i++)
        // {
        //     dungeons[i].gameObject.SetActive(false);
        // }
        starterDungeon.gameObject.SetActive(true);
        currentDungeon = starterDungeon;
        yield return null;
    }

    private static Dungeon SelectRandomDungeon(DungeonNameType changeToDungeon)
    {
        List<Dungeon> filteredDungeons = dungeons.FindAll(dungeon => dungeon.dungeonNameType == changeToDungeon);
        return filteredDungeons[Random.Range(0, filteredDungeons.Count - 1)];
    }
    public static void ChangeDungeon(DungeonNameType changeToDungeon)
    {
        currentDungeon.gameObject.SetActive(false);
        currentDungeon = SelectRandomDungeon(changeToDungeon);
        currentDungeon.gameObject.SetActive(true);
        PlayerSingleton.GetInstance().transform.position = currentDungeon.transform.position + new Vector3(0, 2, 0);
    }
}
