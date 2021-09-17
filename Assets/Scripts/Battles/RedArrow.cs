using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedArrow : MonoBehaviour
{
    private BattleControls battleControls;
    private NewBattleSystem battleSystem;

    private int currentPosition = 4; //4, 5, 6
    private bool canChangePosition = true;
    private bool canSelect = false;

    // Start is called before the first frame update
    void Start()
    {
        battleControls = FindObjectOfType<BattleControls>();
        battleSystem = FindObjectOfType<NewBattleSystem>();
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        float arrowInput = battleControls.playerCS.Battles.Move.ReadValue<float>();
        //Debug.Log("arrowinput " + arrowInput);
        if (canChangePosition)
        {
            if (arrowInput == 1 && currentPosition != 6)
            {
                canChangePosition = false;
                currentPosition += 1;
                ChangePos(true);
            }
            else if(arrowInput == -1 && currentPosition != 4)
            {
                canChangePosition = false;
                currentPosition -= 1;
                ChangePos(false);
            }
        }

        float enterInput = battleControls.playerCS.Battles.Select.ReadValue<float>();
        if(enterInput == 1 && canSelect)
        {
            //battleSystem.LogAttack(AttackType.STRIKE, currentPosition);
            battleSystem.LogAttack(currentPosition);
            Destroy(gameObject);
        }
    }

    private void ChangePos(bool goingRight)
    {
        //Debug.Log(currentPosition);

        if (goingRight)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += 4;
            transform.position = newPosition;
        }
        else
        {
            Vector3 newPosition = transform.position;
            newPosition.x -= 4;
            transform.position = newPosition;
        }
        StartCoroutine(ChangePosDelay());

    }

    IEnumerator ChangePosDelay()
    {
        yield return new WaitForSeconds(0.25f);
        canChangePosition = true;
    }

    IEnumerator StartDelay()//prevents the enter press from the battle system also applying immediately to the arrow
    {
        yield return new WaitForSeconds(0.25f);
        canSelect = true;
    }
}
