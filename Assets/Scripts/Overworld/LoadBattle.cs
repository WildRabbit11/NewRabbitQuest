using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBattle : MonoBehaviour
{
    private PlayerParty playerParty;
    private EnemyParty enemyParty;
    //private BattleImporter battleImporter;

    private WorldManager[] worldManagers;
    private WorldManager worldManager;

    void Start()
    {
        //Debug.Log("start");
        playerParty = FindObjectOfType<PlayerParty>();
        enemyParty = GetComponent<EnemyParty>();
        worldManagers = FindObjectsOfType<WorldManager>();

        bool managerFlag = false;
        foreach (WorldManager i in worldManagers)
        {
            if (i.active)
            {
                worldManager = i;
                managerFlag = true;
            }
        }
        if (!managerFlag)
        {
            worldManager = FindObjectOfType<WorldManager>();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Detected");
        if(col.tag == "Player")
        {
            worldManager.playerPrefabs = playerParty.playerPartyActive;
            worldManager.enemyPrefabs = enemyParty.enemyParty;
            worldManager.LoadBattlePrep(enemyParty.enemyID);
            StartCoroutine(LaunchBattle());
        }
    }

    IEnumerator LaunchBattle()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
