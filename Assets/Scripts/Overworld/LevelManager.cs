using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private WorldManager[] worldManagers;
    private WorldManager worldManager;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        bool managerFlag = false;
        worldManagers = FindObjectsOfType<WorldManager>();
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

        player = FindObjectOfType<PlayerController>();

        //worldManager.enemyCharacterCheck();//deletes defeated enemies --> not needed as the enemies do this themselves
        if (worldManager.returningFromBattle)
        {
            Debug.Log("RETVRN");
            Vector2 newPlayerPos = new Vector2(worldManager.currentPlayerX, worldManager.currentPlayerY);
            player.transform.position = newPlayerPos;

            worldManager.returningFromBattle = false;
        }
    }
}
