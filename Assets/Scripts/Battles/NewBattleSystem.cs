using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, EFFECTSPHASE, PLAYERPHASE, ENEMYPHASE, FIGHTPHASE, WON, LOST, ESCAPED }

public enum AttackType { STRIKE, MOVE1, MOVE2, MOVE3 }

public class NewBattleSystem : MonoBehaviour
{
    public BattleState state;

    private SetHealthBars setHealthBars;
    private UpdateMoves updateMoves;

    private WorldManager[] worldManagers;
    private WorldManager worldManager;

    private List<Unit> playerUnits;
    private List<Unit> enemyUnits;
    private List<LogAType> logAttacks;
    private List<bool> pUnitsActive;
    private List<bool> eUnitsActive;
    private List<GameObject> pGameObjects;
    private List<GameObject> eGameObjects;

    public Transform pPos1;
    public Transform pPos2;
    public Transform pPos3;
    public Transform ePos1;
    public Transform ePos2;
    public Transform ePos3;

    private int count; //used for keeping track during loops
    private int currentUnitID;
    private int count2; //used for keeping track during loops while count is alreaady in use
    private int healthCount;

    private AttackType currentAttackType;
    private SortByCasterSpeed sortByCasterSpeed;//class found in LogAType script

    public Text dialogueText;
    public GameObject redArrowPrefab;

    private Unit currentUnit;
    private Unit targetUnit;
    private LogAType currentAttack;
    private int damageDealt;
    private bool playerFlag;

    private bool playerWinCheck;
    private bool playerLoseCheck;

    private bool canMove;
    //private int totalActiveUnits;

    //private MovesAndEffects.MoveList currentSpell;
    private Moves newMove;

    private GameObject gameObjectP1;
    private GameObject gameObjectP2;
    private GameObject gameObjectP3;
    private GameObject gameObjectE1;
    private GameObject gameObjectE2;
    private GameObject gameObjectE3;

    private GameObject attackingGameObject;
    private GameObject defendingGameObject;
    private SpriteRenderer attackingSpriteRenderer;
    private SpriteRenderer defendingSpriteRenderer;

    private bool importerFlag = false;

    private bool specialReturn = false;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        worldManagers = FindObjectsOfType<WorldManager>();
        foreach(WorldManager i in worldManagers)
        {
            if (i.active)
            {
                worldManager = i;
                importerFlag = true;
            }
        }
        if (!importerFlag)
        {
            worldManager = FindObjectOfType<WorldManager>();
        }




        sortByCasterSpeed = new SortByCasterSpeed();

        setHealthBars = GetComponent<SetHealthBars>();
        updateMoves = GetComponent<UpdateMoves>();
        updateMoves.SetButtonsInactive();

        logAttacks = new List<LogAType>();
        pUnitsActive = new List<bool>();
        eUnitsActive = new List<bool>();

        pGameObjects = new List<GameObject>();
        eGameObjects = new List<GameObject>();

        //Debug.Log("Length " + importer.playerPrefabs.Length);
        //if(importer.playerPrefabs.Length == 1)
        //{
        //    pPos1.position = pPos2.position;
        //}
        //if(importer.enemyPrefabs.Length == 1)
        //{
        //    ePos1.position = ePos2.position;
        //}

        playerUnits = new List<Unit>();
        count = 0;
        foreach (GameObject i in worldManager.playerPrefabs)
        {
            pUnitsActive.Add(true);
            GameObject k;
            if (count == 0)
            {
                k = Instantiate(i, pPos1);
                gameObjectP1 = k;
            }
            else if (count == 1)
            {
                k = Instantiate(i, pPos2);
                gameObjectP2 = k;
            }
            else if (count == 2)
            {
                k = Instantiate(i, pPos3);
                gameObjectP3 = k;
            }
            else
            {
                Debug.Log("Error: Attempting to deploy more than 3 units to playerside battlefield");
                k = null;
            }
            pGameObjects.Add(k);
            Unit j = k.GetComponent<Unit>();
            playerUnits.Add(j);
            count += 1;
        }
        //Debug.Log(playerUnits.Count);

        enemyUnits = new List<Unit>();
        count = 0;
        foreach(GameObject i in worldManager.enemyPrefabs)
        {
            eUnitsActive.Add(true);
            GameObject k;
            if (count == 0)
            {
                k = Instantiate(i, ePos1);
                gameObjectE1 = k;
            }
            else if (count == 1)
            {
                k = Instantiate(i, ePos2);
                gameObjectE2 = k;
            }
            else if (count == 2)
            {
                k = Instantiate(i, ePos3);
                gameObjectE3 = k;
            }
            else
            {
                Debug.Log("Error: Attempting to deploy more than 3 units to enemyside battlefield");
                k = null;
            }
            eGameObjects.Add(k);
            Unit j = k.GetComponent<Unit>();
            enemyUnits.Add(j);
            count += 1;
        }
        //getting EUnitsActive up to 3 values
        while(eUnitsActive.Count < 3)
        {
            eUnitsActive.Add(false);
        }

        //Debug.Log(enemyUnits.Count);

        count = 0;
        foreach(Unit i in playerUnits)
        {
            Debug.Log("id " + count + " health: " + i.currentHP);
            count += 1;
        }
        count = 4;
        foreach (Unit i in enemyUnits)
        {
            Debug.Log("id " + count + " health: " + i.currentHP);
            count += 1;
        }

        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        HealthBarUpdate();
        count = 0;
        dialogueText.text = "Enemies approach...";

        yield return new WaitForSeconds(2f);


        currentUnitID = 0;
        state = BattleState.EFFECTSPHASE;
        EffectsPhase();
    }

    private void HealthBarUpdate()
    {
        healthCount = 0;
        foreach (Unit i in playerUnits)
        {
            if (healthCount == 0)
                setHealthBars.RefreshBars(0, i);
            else if (healthCount == 1)
                setHealthBars.RefreshBars(1, i);
            else if (healthCount == 2)
                setHealthBars.RefreshBars(2, i);
            else
                Debug.Log("Error: Attempting to deploy more than 3 units to playerside battlefield");
            healthCount += 1;
        }
        healthCount = 0;
        foreach (Unit i in enemyUnits)
        {
            if (healthCount == 0)
                setHealthBars.RefreshBars(4, i);
            else if (healthCount == 1)
                setHealthBars.RefreshBars(5, i);
            else if (healthCount == 2)
                setHealthBars.RefreshBars(6, i);
            else
                Debug.Log("Error: Attempting to deploy more than 3 units to enemyside battlefield");
            healthCount += 1;
        }
    }

    private void EffectsPhase()
    {

        //TO DO: Add a loop which runs through all six characters and applies their unique/status effects for the turn

        state = BattleState.PLAYERPHASE;
        PlayerPhase();
    }

    private void PlayerPhase()
    {
        if (pUnitsActive[currentUnitID])
        {
            updateMoves.ChangeButtonText(playerUnits[currentUnitID]);
            dialogueText.text = "Choose an action for " + playerUnits[currentUnitID].unitName + ":";
            updateMoves.SetButtonsActive();
        }
        else
        {
            currentUnitID += 1;
            NextUnit();
        }
    }

    public void OnStrikeButton()
    {
        currentAttackType = AttackType.STRIKE;
        if (state != BattleState.PLAYERPHASE)
            return;
        updateMoves.SetButtonsInactive();
        dialogueText.text = "Choose an charcter to strike";
        Instantiate(redArrowPrefab, new Vector3(ePos1.position.x, ePos1.position.y + 1.75f, ePos1.position.z), Quaternion.identity);
    }

    public void OnFleeButton()
    {
        //lowest speed of player unit vs highest speed of enemy unit
    }

    public void OnMove1Button()
    {
        currentAttackType = AttackType.MOVE1;
        if (state != BattleState.PLAYERPHASE)
            return;
        updateMoves.SetButtonsInactive();
        dialogueText.text = "Choose an charcter to target";
        Instantiate(redArrowPrefab, new Vector3(ePos1.position.x, ePos1.position.y + 1.75f, ePos1.position.z), Quaternion.identity);
    }

    public void OnMove2Button()
    {
        currentAttackType = AttackType.MOVE2;
        if (state != BattleState.PLAYERPHASE)
            return;
        updateMoves.SetButtonsInactive();
        dialogueText.text = "Choose an charcter to target";
        Instantiate(redArrowPrefab, new Vector3(ePos1.position.x, ePos1.position.y + 1.75f, ePos1.position.z), Quaternion.identity);
    }

    public void OnMove3Button()
    {
        currentAttackType = AttackType.MOVE3;
        if (state != BattleState.PLAYERPHASE)
            return;
        updateMoves.SetButtonsInactive();
        dialogueText.text = "Choose an charcter to target";
        Instantiate(redArrowPrefab, new Vector3(ePos1.position.x, ePos1.position.y + 1.75f, ePos1.position.z), Quaternion.identity);
    }

    public void LogAttack(int enemyID)
    {
        LogAType attackData;
        if(state == BattleState.PLAYERPHASE)
        {
            attackData = new LogAType(currentUnitID, playerUnits[currentUnitID].speed, currentAttackType, enemyID);
        }
        else
        {
            attackData = new LogAType(currentUnitID, enemyUnits[currentUnitID - playerUnits.Count].speed, currentAttackType, enemyID);
        }
        logAttacks.Add(attackData);
        Debug.Log("tree");
        currentUnitID += 1;
        NextUnit();
    }

    private void NextUnit()
    {
        if((currentUnitID) < playerUnits.Count)
        {
            Debug.Log("player currentUnitID " + currentUnitID);
            PlayerPhase();
        }
        else if(currentUnitID < (enemyUnits.Count + playerUnits.Count))
        {
            Debug.Log("enemy currentUnitID " + currentUnitID);
            Debug.Log("enemyUnits.Count + playerUnits.Count " + (enemyUnits.Count + playerUnits.Count));
            EnemyPhase();
        }
        else
        {
            FightPhase();
        }
    }

    private void EnemyPhase()
    {
        state = BattleState.ENEMYPHASE;
        currentAttackType = AttackType.STRIKE;
        Debug.Log("enemyPhase");
        //EnemyAI - Improve later
        if (eUnitsActive[currentUnitID - playerUnits.Count])
        {
            if (playerUnits[0].currentHP > 0)
            {
                Debug.Log("Targeting 0");
                LogAttack(0);
            }
            else if (playerUnits[1].currentHP > 0)
            {
                Debug.Log("Targeting 1");
                LogAttack(1);
            }
            else
            {
                Debug.Log("Targeting 2");
                LogAttack(2);
            }
        }
        else
        {
            currentUnitID += 1;
            NextUnit();
        }
    }

    private void FightPhase()
    {
        state = BattleState.FIGHTPHASE;
        Debug.Log("FightPhase");

        //foreach(LogAType i in logAttacks)
        //{
        //    //Debug.Log(" casterID: " + i.casterID + " casterSpeed" + i.casterSpeed + " currentAttackType: " + i.attackType + " enemyID " + i.targetID);
        //}
        logAttacks.Sort(sortByCasterSpeed);
        Debug.Log("Sorted");
        //foreach (LogAType i in logAttacks)
        //{
        //    //Debug.Log(" casterID: " + i.casterID + " casterSpeed" + i.casterSpeed + " currentAttackType: " + i.attackType + " enemyID " + i.targetID);
        //}

        count = 0;
        FightLoop();
    }

    private void FightLoop()
    {
        Debug.Log("FightLoop Check 1");
        foreach (LogAType i in logAttacks)
        {
            Debug.Log("CasterID" + i.casterID);
        }
        Debug.Log("LOG COUNT " + logAttacks.Count);
        if (count < logAttacks.Count)
        {
            currentAttack = logAttacks[count];
            //player attacks
            if (currentAttack.casterID < playerUnits.Count)
            {
                if (!eUnitsActive[0] && !eUnitsActive[1] && !eUnitsActive[2])
                {
                    specialReturn = true;
                }
                else
                {
                    bool targetCheck = false;
                    while (targetCheck == false)
                    {
                        currentUnit = playerUnits[currentAttack.casterID];
                        if (currentAttack.targetID == 4)
                        {
                            defendingGameObject = gameObjectE1;
                            targetUnit = enemyUnits[0];
                            if (!eUnitsActive[0])
                                currentAttack.targetID = 5;
                            else
                                targetCheck = true;
                        }
                        if (currentAttack.targetID == 5)
                        {
                            defendingGameObject = gameObjectE2;
                            if (enemyUnits.Count > 1)//if statement added later to prevent error of there being no enemyUnits[1] when only one enemy in scene
                                targetUnit = enemyUnits[1];
                            if (!eUnitsActive[1])
                                currentAttack.targetID = 6;
                            else targetCheck = true;
                        }
                        if (currentAttack.targetID == 6)
                        {
                            defendingGameObject = gameObjectE3;
                            if (enemyUnits.Count > 2)
                                targetUnit = enemyUnits[2];
                            if (!eUnitsActive[2])
                                currentAttack.targetID = 4;
                            else targetCheck = true;
                        }
                    }
                    Debug.Log("TargetID_" + currentAttack.targetID);
                    //targetUnit = enemyUnits[currentAttack.targetID - playerUnits.Count];
                    playerFlag = true;
                }
            }
            else
            {
                currentUnit = enemyUnits[currentAttack.casterID - playerUnits.Count];
                if (!pUnitsActive[currentAttack.targetID])
                {
                    count2 = 0;
                    foreach (bool i in pUnitsActive)
                    {
                        if (i == true)
                        {
                            Debug.Log("count2 " + count2);
                            currentAttack.targetID = count2;
                        }
                        count2 += 1;
                    }
                }
                targetUnit = playerUnits[currentAttack.targetID];
                //setting the player defending game objects
                if (currentAttack.targetID == 0)
                    defendingGameObject = gameObjectP1;
                else if (currentAttack.targetID == 1)
                    defendingGameObject = gameObjectP2;
                else if (currentAttack.targetID == 2)
                    defendingGameObject = gameObjectP3;

                playerFlag = false;
            }
            if (!specialReturn)
            {
                Debug.Log("EarlyCheckA");
                canMove = false;
                if (playerFlag && pUnitsActive[currentAttack.casterID])
                    canMove = true;
                if (!playerFlag && eUnitsActive[currentAttack.casterID - playerUnits.Count])
                    canMove = true;
                Debug.Log("EarlyCheckB");
                //setting the attacking gameobjects
                if (playerFlag)
                {
                    if (currentAttack.casterID == 0)
                        attackingGameObject = gameObjectP1;
                    else if (currentAttack.casterID == 1)
                        attackingGameObject = gameObjectP2;
                    else if (currentAttack.casterID == 2)
                        attackingGameObject = gameObjectP3;
                }
                else if (!playerFlag)
                {
                    if (currentAttack.casterID == playerUnits.Count)
                        attackingGameObject = gameObjectE1;
                    else if (currentAttack.casterID == (playerUnits.Count + 1))
                        attackingGameObject = gameObjectE2;
                    else if (currentAttack.casterID == (playerUnits.Count + 2))
                        attackingGameObject = gameObjectE3;
                }
                Debug.Log("EarlyCheckC");
                count += 1;
                if (canMove)
                {
                    if (currentAttack.attackType == AttackType.STRIKE)
                    {
                        Strike();
                    }
                    else
                    {
                        SpellCast(currentAttack.attackType);
                    }
                }
                else
                    FightLoop();

            }
            else
                FightOutcomeCheck();
        }
        else
        {
            FightOutcomeCheck();
        }
    }

    private void FightOutcomeCheck()
    {
        Debug.Log("FightOutcomeCheck Check 1");
        foreach (Unit i in playerUnits)
        {
            Debug.Log("Player health: " + i.currentHP);
        }
        foreach (Unit i in enemyUnits)
        {
            Debug.Log("Enemy health: " + i.currentHP);
        }
        Debug.Log("FightOutcomeCheck Check 2");
        playerWinCheck = true;
        foreach(bool i in eUnitsActive)
        {
            if (i == true)
            {
                Debug.Log("FightOutcomeCheck Check 2a");
                playerWinCheck = false;
            }
        }
        playerLoseCheck = true;
        foreach(bool i in pUnitsActive)
        {
            if (i == true)
            {
                Debug.Log("FightOutcomeCheck Check 2b");
                playerLoseCheck = false;
            }
        }
        Debug.Log("PlayerWinCheck: " + playerWinCheck);
        Debug.Log("PlayerLoseCheck: " + playerLoseCheck);
        Debug.Log("FightOutcomeCheck Check 3");
        if (playerWinCheck)
        {
            Debug.Log("FightOutcomeCheck Check 3a");
            state = BattleState.WON;
            dialogueText.text = "You have won the fight!";
            if (worldManager.returningFromBattle)
            {
                StartCoroutine(VictoryReturn());
            }
        }
        else if (playerLoseCheck)
        {
            Debug.Log("FightOutcomeCheck Check 3b");
            state = BattleState.LOST;
            dialogueText.text = "You have lost the fight!";
        }
        else
        {
            //if fight continuing
            count = 0;
            currentUnitID = 0;
            logAttacks.Clear();

            Debug.Log("FightOutcomeCheck Check 4");
            EffectsPhase();
        }
    }


    private void Strike()
    {
        defendingSpriteRenderer = defendingGameObject.GetComponentInChildren<SpriteRenderer>();
        attackingSpriteRenderer = attackingGameObject.GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(BattleColourChanges());

        damageDealt = currentUnit.phyDamage - Mathf.Abs((targetUnit.phyDefence / 2));
        if (damageDealt < 1)
        {
            damageDealt = 1;
            Debug.Log("Damage set to 1 due to high target defence");
        }
        dialogueText.text = currentUnit.unitName + " strikes " + targetUnit.unitName + " dealing " + damageDealt + " damage!";
        //Debug.Log("target health " + targetUnit.currentHP);
        targetUnit.currentHP -= damageDealt;
        //Debug.Log("Strike " + currentAttack.targetID + "dealing " + damageDealt);
        //Debug.Log("New health " + targetUnit.currentHP);
        //setHealthBars.RefreshBars(currentAttack.targetID, targetUnit);
        UpdateLists();
    }

    private void SpellCast(AttackType attType)
    {
        defendingSpriteRenderer = defendingGameObject.GetComponentInChildren<SpriteRenderer>();
        attackingSpriteRenderer = attackingGameObject.GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(BattleColourChanges());

        if (attType == AttackType.MOVE1)
            newMove = currentUnit.move1;
        else if (attType == AttackType.MOVE2)
            newMove = currentUnit.move2;
         else if (attType == AttackType.MOVE3)
            newMove = currentUnit.move3;

        var currentSpell = MovesAndEffects.MoveList(newMove);
        //name, damage, manacost, status effect, %chance of applying status effect
        if (currentSpell.Item3 < currentUnit.currentMana)
        {
            damageDealt = (currentSpell.Item2 + currentUnit.magDamage) - Mathf.Abs((targetUnit.magDefence / 2));
            if (damageDealt < 1)
            {
                damageDealt = 1;
                Debug.Log("Damage set to 1 due to high target defence");
            }
            //ADD STATUS EFFECT SECTION
            dialogueText.text = currentUnit.unitName + " uses " + currentSpell.Item1 + " on " + targetUnit.unitName + " dealing " + damageDealt + " damage!";
            targetUnit.currentHP -= damageDealt;
            currentUnit.currentMana -= currentSpell.Item3;
        }
        else
        {
            dialogueText.text = currentUnit.unitName + " attempted to cast " + currentSpell.Item1 + "but did not have enough mana";
        }
        UpdateLists();
    }



    private void UpdateLists()
    {
        if (playerFlag)
        {
            if (currentAttack.targetID == 4)
                enemyUnits[0] = targetUnit;
            else if (currentAttack.targetID == 5)
                enemyUnits[1] = targetUnit;
            else if (currentAttack.targetID == 6)
                enemyUnits[2] = targetUnit;
        }
        else
        {
            playerUnits[currentAttack.targetID] = targetUnit;
        }
        HealthBarUpdate();
        StartCoroutine(SurviveCheck());
        //SurviveCheck();
    }

    IEnumerator SurviveCheck()//checks if the unit which took damage is still alive
    //private void SurviveCheck()
    {
        Debug.Log("SR Check 1a");
        yield return new WaitForSeconds(1f);
        Debug.Log("SR Check 1b");
        if (targetUnit.currentHP <= 0 && playerFlag)
        {
            Debug.Log("SR Check 1c");
            if (currentAttack.targetID == 4)
            {
                eUnitsActive[0] = false;
                Destroy(eGameObjects[0]);
                Debug.Log("SR Check 1d");
            }
            else if (currentAttack.targetID == 5)
            {
                eUnitsActive[1] = false;
                Destroy(eGameObjects[1]);
                Debug.Log("SR Check 1e");
            }
            else if (currentAttack.targetID == 6)
            {
                eUnitsActive[2] = false;
                Destroy(eGameObjects[2]);
                Debug.Log("SR Check 1f");
            }
        }
        else if (targetUnit.currentHP <= 0 && !playerFlag)
        {
            pUnitsActive[currentAttack.targetID] = false;
            Destroy(pGameObjects[currentAttack.targetID]);
            Debug.Log("SR Check 1g");
        }
        Debug.Log("SR Check 2");
        StartCoroutine(BattleDelay());
        //BattleDelay();
    }

    IEnumerator BattleDelay()
    //private void BattleDelay()
    {
        Debug.Log("BD Check 1");
        yield return new WaitForSeconds(1f);
        Debug.Log("BD Check 2");
        FightLoop();
    }

    IEnumerator BattleColourChanges()
    {
        defendingSpriteRenderer.color = new Color(1, 0, 0, 1); //turns sprite red
        //attackingSpriteRenderer.color = new Color(0, 0, 1, 1);
        if (playerFlag)
        {
            defendingGameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -20f));
            attackingGameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -20f));
        }
        else
        {
            defendingGameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 20f));
            attackingGameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 20f));
        }
        yield return new WaitForSeconds(0.75f);
        defendingSpriteRenderer.color = new Color(1, 1, 1, 1);
        defendingGameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //attackingSpriteRenderer.color = new Color(1, 1, 1, 1);
        attackingGameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    IEnumerator VictoryReturn()
    {
        Debug.Log("VR Check 1");
        yield return new WaitForSeconds(3f);
        Debug.Log("VR Check 2");
        count = 0;
        GameObject[] endPlayerParty = new GameObject[worldManager.playerPrefabs.Length];
        Debug.Log("VR Check 3");
        foreach (GameObject i in worldManager.playerPrefabs)
        {
            Debug.Log("VR Check 4 count:" + count);
            i.GetComponent<Unit>().currentHP = playerUnits[count].currentHP;
            Debug.Log("VR Check 5 count:" + count);
            endPlayerParty[count] = i;
            Debug.Log("VR Check 6 count:" + count);
            count += 1;
        }
        Debug.Log("VR Check 7");
        worldManager.playerPartyGameObjects = endPlayerParty;
        Debug.Log("VR Check 8");
        worldManager.VictoryReturn();
    }
}
