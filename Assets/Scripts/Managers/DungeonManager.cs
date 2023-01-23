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
        Debug.Log("Number of dungeons: "+ dungeons.Count);
        currentDungeon.gameObject.SetActive(false);
        currentDungeon = SelectRandomDungeon(changeToDungeon);
        currentDungeon.gameObject.SetActive(true);
        GameObject playerPosition = PlayerSingleton.GetInstance().gameObject;
        //PlayerSingleton.GetInstance().gameObject.transform.position = currentDungeon.transform.position + new Vector3(0, 2, 0);
        playerPosition.transform.position = currentDungeon.transform.position + new Vector3(1.2f, 2, -2.7f);
        Debug.Log(currentDungeon.name);
        Debug.Log("Current dungeon position: " + currentDungeon.transform.position);
        Debug.Log("Player position: " + playerPosition.transform.localPosition);
        Debug.Log("Player world position: " + playerPosition.transform.position);

    }
    public void EmptyDungeonsList()
    {
        dungeons.Clear();
    }
}
