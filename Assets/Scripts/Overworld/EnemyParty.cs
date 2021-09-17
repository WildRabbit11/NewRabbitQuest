using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParty : MonoBehaviour
{
    public int enemyID;

    public GameObject[] enemyParty;

    private WorldManager[] worldManagers;
    private WorldManager worldManager;

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
        Debug.Log(worldManager.presetEnemyStates[enemyID]);
        if (!worldManager.presetEnemyStates[enemyID])
        {
            Destroy(gameObject);
        }
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
