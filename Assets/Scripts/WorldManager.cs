using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    private WorldManager[] worldManagers;
    private PlayerParty player;
    [HideInInspector] public float currentPlayerX;
    [HideInInspector] public float currentPlayerY;

    private EnemyParty[] listOfEnemies;
    [HideInInspector] public int activeEnemyID;

    [HideInInspector] public bool gameJustLaunchedFlag = true; //used by PlayerParty.cs to decide whether to reset the unit's values to default

    //from BattleImporter
    public GameObject[] playerPrefabs;
    public GameObject[] enemyPrefabs;

    [HideInInspector] public bool active = false;
    [HideInInspector] public bool returningFromBattle;

    //the latest enemyid should always be one less than the totalPresetEnemies
    private int totalPresetEnemies = 2;//increase by one for each enemy added to the game
    [HideInInspector] public List<bool> presetEnemyStates;

    [HideInInspector] public GameObject[] playerPartyGameObjects;

    private string preBattleScene;

    private int count;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        worldManagers = FindObjectsOfType<WorldManager>();
        if (worldManagers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
            active = true;

        count = 0;
        while (count < totalPresetEnemies)
        {
            presetEnemyStates.Add(true);
            count += 1;
        }
    }

    void Start()
    {
        player = FindObjectOfType<PlayerParty>();
        //playerPartyGameObjects = player.playerPartyActive; --> moved to LoadBattlePrep
    }

    public void LoadBattlePrep(int enemyID)//should recieve 
    {
        playerPartyGameObjects = player.playerPartyActive;
        Debug.Log("enemyID" + enemyID);
        player = FindObjectOfType<PlayerParty>();
        preBattleScene = SceneManager.GetActiveScene().name;
        returningFromBattle = true;
        currentPlayerX = player.transform.position.x;
        currentPlayerY = player.transform.position.y;
        activeEnemyID = enemyID;
    }

    public void enemyCharacterCheck()//this function should not need to be called as the EnemyParty script covers its function
    {
        listOfEnemies = FindObjectsOfType<EnemyParty>();
        foreach (EnemyParty i in listOfEnemies)
        {
            if (!presetEnemyStates[i.enemyID])
                Destroy(i.gameObject);
        }
    }

    public void VictoryReturn()
    {
        presetEnemyStates[activeEnemyID] = false;
        SceneManager.LoadScene(preBattleScene);
        StartCoroutine(VictoryReturnSetUpDelay());
    }

    IEnumerator VictoryReturnSetUpDelay()
    {
        yield return new WaitForSeconds(0.3f);
        player = FindObjectOfType<PlayerParty>();
        player.playerPartyActive = new GameObject[playerPartyGameObjects.Length];
        Debug.Log("playerPartyGameObjects.Length " + playerPartyGameObjects.Length);
        player.playerPartyActive = playerPartyGameObjects;
    }
}
