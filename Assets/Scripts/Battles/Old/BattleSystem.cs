using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BattleSystem : MonoBehaviour
{
    //private bool buttonsActive = false; //defines whether the buttons will do anything while pressed

    public BattleState state;

    public GameObject playerPrefab1;
    public GameObject playerPrefab2;
    public GameObject playerPrefab3;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    public GameObject redArrowPrefab;

    private Unit playerUnit1;
    private Unit playerUnit2;
    private Unit playerUnit3;
    private Unit enemyUnit1;
    private Unit enemyUnit2;
    private Unit enemyUnit3;

    private int currentUnitID;
    private Unit currentUnit;
    private Unit defUnit;

    public Transform pPos1;
    public Transform pPos2;
    public Transform pPos3;
    public Transform ePos1;
    public Transform ePos2;
    public Transform ePos3;

    public Text dialogueText;

    private SetHealthBars setHealthBars;
    private UpdateMoves updateMoves;

    private int damageDealt;

    private int firstMove;
    private int secondMove;
    private int thirdMove;
    private int fourthMove;
    private int fifthMove;
    private int sixthMove;

    private bool sortChanges;
    private int currentFightState;

    private AttackType logAttackType1;
    private int logAttackTarget1;
    private AttackType logAttackType2;
    private int logAttackTarget2;
    private AttackType logAttackType3;
    private int logAttackTarget3;
    private AttackType logAttackType4;
    private int logAttackTarget4;
    private AttackType logAttackType5;
    private int logAttackTarget5;
    private AttackType logAttackType6;
    private int logAttackTarget6;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        setHealthBars = GetComponent<SetHealthBars>();
        updateMoves = GetComponent<UpdateMoves>();
        updateMoves.SetButtonsInactive();
        StartCoroutine(SetupBattle());
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    IEnumerator SetupBattle()
    {
        GameObject playerGO1 = Instantiate(playerPrefab1, pPos1); //GO stands for Game Object
        playerUnit1 = playerGO1.GetComponent<Unit>();
        GameObject playerGO2 = Instantiate(playerPrefab2, pPos2);
        playerUnit2 = playerGO2.GetComponent<Unit>();
        GameObject playerGO3 = Instantiate(playerPrefab3, pPos3);
        playerUnit3 = playerGO3.GetComponent<Unit>();

        GameObject enemyGO1 = Instantiate(enemyPrefab1, ePos1);
        enemyUnit1 = enemyGO1.GetComponent<Unit>();
        GameObject enemyGO2 = Instantiate(enemyPrefab2, ePos2);
        enemyUnit2 = enemyGO2.GetComponent<Unit>();
        GameObject enemyGO3 = Instantiate(enemyPrefab3, ePos3);
        enemyUnit3 = enemyGO3.GetComponent<Unit>();

        setHealthBars.RefreshBars(1, playerUnit1);
        setHealthBars.RefreshBars(2, playerUnit2);
        setHealthBars.RefreshBars(3, playerUnit3);
        setHealthBars.RefreshBars(4, enemyUnit1);
        setHealthBars.RefreshBars(5, enemyUnit2);
        setHealthBars.RefreshBars(6, enemyUnit3);

        

        dialogueText.text = "Enemies approach...";

        yield return new WaitForSeconds(2f);

        state = BattleState.EFFECTSPHASE;
        EffectsPhase();

    }

    private void EffectsPhase()
    {
        currentUnitID = 1;
        currentUnit = playerUnit1;
        updateMoves.ChangeButtonText(currentUnit);

        //TO DO: Add a loop which runs through all six characters and applies their unique/status effects for the turn


        state = BattleState.PLAYERPHASE;
        PlayerPhase(currentUnit);
    }

    void PlayerPhase(Unit currentUnit)//aka Player's Turn
    {
        dialogueText.text = "Choose an action for " + currentUnit.unitName + ":";
        updateMoves.SetButtonsActive();
        //buttonsActive = true;
    }

    public void OnStrikeButton()
    {
        if (state != BattleState.PLAYERPHASE)
            return;
        updateMoves.SetButtonsInactive();
        dialogueText.text = "Choose an charcter to strike";
        Instantiate(redArrowPrefab, new Vector3(ePos1.position.x, ePos1.position.y + 1.75f, ePos1.position.z), Quaternion.identity);
    }

    private void Strike(int enemyID)//input may need tweaking
    {
        Debug.Log("Strike " + enemyID);
        defUnit = defendingUnit(enemyID);
        damageDealt = Mathf.Abs(currentUnit.phyDamage - (defUnit.phyDefence / 2));
        dialogueText.text = currentUnit.unitName + " strikes " + defUnit.unitName + " dealing " + damageDealt + " damage!";
        defUnit.currentHP -= damageDealt;
        setHealthBars.RefreshBars(enemyID, defUnit);
        StartCoroutine(BattleDelay());
    }

    public void LogAttack(AttackType aType, int enemyID)
    {
        if(currentUnitID == 1)
        {
            logAttackType1 = aType;
            logAttackTarget1 = enemyID;
        }
        else if(currentUnitID == 2)
        {
            logAttackType2 = aType;
            logAttackTarget2 = enemyID;
        }
        else if (currentUnitID == 3)
        {
            logAttackType3 = aType;
            logAttackTarget3 = enemyID;
        }
        else if (currentUnitID == 4)
        {
            logAttackType4 = aType;
            logAttackTarget4 = enemyID;
        }
        else if (currentUnitID == 5)
        {
            logAttackType5 = aType;
            logAttackTarget5 = enemyID;
        }
        else if (currentUnitID == 6)
        {
            logAttackType6 = aType;
            logAttackTarget6 = enemyID;
        }

        NextUnit();
    }

    private void NextUnit()
    {
        if(currentUnitID == 1)
        {
            currentUnitID = 2;
            currentUnit = playerUnit2;
            updateMoves.ChangeButtonText(currentUnit);
            PlayerPhase(currentUnit);
        }
        else if(currentUnitID == 2)
        {
            currentUnitID = 3;
            currentUnit = playerUnit3;
            updateMoves.ChangeButtonText(currentUnit);
            PlayerPhase(currentUnit);
        }
        else if (currentUnitID == 3)
        {
            currentUnitID = 4;
            currentUnit = enemyUnit1;
            EnemyPhase();
        }
        else if (currentUnitID == 4)
        {
            currentUnitID = 5;
            currentUnit = enemyUnit2;
            EnemyPhase();
        }
        else if (currentUnitID == 5)
        {
            currentUnitID = 6;
            currentUnit = enemyUnit3;
            EnemyPhase();
        }
        else if (currentUnitID == 6)
        {
            FightPhase();
        }
    }

    private void EnemyPhase()
    {
        state = BattleState.ENEMYPHASE;

        //Enemy AI, improve later
        if (playerUnit1.currentHP > 0)
        {
            LogAttack(AttackType.STRIKE, 1);
        }
        else if(playerUnit2.currentHP > 0)
        {
            LogAttack(AttackType.STRIKE, 2);
        }
        else
        {
            LogAttack(AttackType.STRIKE, 3);
        }

    }

    private void FightPhase()
    {
        state = BattleState.FIGHTPHASE;
        
        firstMove = 1;
        secondMove = 2;
        thirdMove = 3;
        fourthMove = 4;
        fifthMove = 5;
        sixthMove = 6;

        //calculate order based on speed
        sortChanges = true;
        while(sortChanges == true)
        {
            SpeedSort();
        }

        currentFightState = 1;
        FightLoop();
    }

    private void FightLoop()
    {
        if(currentFightState == 1)
        {
            currentFightState += 1;
            FightAction(firstMove);
        }
        else if (currentFightState == 2)
        {
            currentFightState += 1;
            FightAction(secondMove);
        }
        else if (currentFightState == 3)
        {
            currentFightState += 1;
            FightAction(thirdMove);
        }
        else if (currentFightState == 4)
        {
            currentFightState += 1;
            FightAction(fourthMove);
        }
        else if (currentFightState == 5)
        {
            currentFightState += 1;
            FightAction(fifthMove);
        }
        else if (currentFightState == 6)
        {
            currentFightState += 1;
            FightAction(sixthMove);
        }
        else
        {
            FightOutcomeCheck();
        }
    }

    private void FightAction(int unitID)
    {
        if(unitID == 1)
        {
            currentUnit = playerUnit1;
            if(logAttackType1 == AttackType.STRIKE)
            {
                Strike(logAttackTarget1);
            }
            //TO DO: add else statements
        }
        else if (unitID == 2)
        {
            currentUnit = playerUnit2;
            if (logAttackType2 == AttackType.STRIKE)
            {
                Strike(logAttackTarget2);
            }
            //TO DO: add else statements
        }
        else if (unitID == 3)
        {
            currentUnit = playerUnit3;
            if (logAttackType3 == AttackType.STRIKE)
            {
                Strike(logAttackTarget3);
            }
            //TO DO: add else statements
        }
        else if (unitID == 4)
        {
            currentUnit = enemyUnit1;
            if (logAttackType4 == AttackType.STRIKE)
            {
                Strike(logAttackTarget4);
            }
            //TO DO: add else statements
        }
        else if (unitID == 5)
        {
            currentUnit = enemyUnit2;
            if (logAttackType5 == AttackType.STRIKE)
            {
                Strike(logAttackTarget5);
            }
            //TO DO: add else statements
        }
        else if (unitID == 6)
        {
            currentUnit = enemyUnit3;
            if (logAttackType6 == AttackType.STRIKE)
            {
                Strike(logAttackTarget6);
            }
            //TO DO: add else statements
        }
    }

    private void FightOutcomeCheck()
    {
        if(playerUnit1.currentHP <= 0 && playerUnit2.currentHP <= 0 && playerUnit3.currentHP <= 0)
        {
            dialogueText.text = "Fight lost! You were defeated!";
            state = BattleState.LOST;
        }
        else if(enemyUnit1.currentHP <= 0 && enemyUnit2.currentHP <= 0 && enemyUnit3.currentHP <= 0)
        {
            dialogueText.text = "Fight won! You were victorious!";
            state = BattleState.WON;
        }
        else
        {
            EffectsPhase();
        }
    }

    private void SpeedSort()//TO DO: create sorting algorithm
    {
        sortChanges = false;
    }

    private Unit defendingUnit(int unitNumber)
    {
        if(unitNumber == 1)
        {
            return playerUnit1;
        }
        else if(unitNumber == 2)
        {
            return playerUnit2;
        }
        else if(unitNumber == 3)
        {
            return playerUnit3;
        }
        else if(unitNumber == 4)
        {
            return enemyUnit1;
        }
        else if(unitNumber == 5)
        {
            return enemyUnit2;
        }
        else
        {
            return enemyUnit3;
        }

    }

    IEnumerator BattleDelay()//prevents the enter press from the battle system also applying immediately to the arrow
    {
        yield return new WaitForSeconds(1.5f);
        FightLoop();
    }

}
