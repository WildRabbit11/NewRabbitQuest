using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleImporter : MonoBehaviour
{
    //script used to import the unit prefabs into the battleSystem

    public GameObject[] playerPrefabs;
    public GameObject[] enemyPrefabs;

    private BattleImporter[] battleImporters;

    [HideInInspector] public bool active = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        battleImporters = FindObjectsOfType<BattleImporter>();
        if (battleImporters.Length > 1)
        {
            Destroy(gameObject);
        }
        else
            active = true;
    }
}
