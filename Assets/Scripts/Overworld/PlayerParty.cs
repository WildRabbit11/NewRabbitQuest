using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    public GameObject[] playerParty;
    [HideInInspector] public GameObject[] playerPartyActive;
    private WorldManager worldManager;

    // Start is called before the first frame update
    void Start()
    {
        worldManager = FindObjectOfType<WorldManager>();
        if (worldManager.gameJustLaunchedFlag)
        {
            foreach(GameObject i in playerParty)
            {
                Unit j = i.GetComponent<Unit>();
                j.maxHP = j.defaultMaxHP;
                j.currentHP = j.maxHP;
            }
            worldManager.gameJustLaunchedFlag = false;
        }
        playerPartyActive = playerParty;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
