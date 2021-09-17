using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoves : MonoBehaviour//this script has grown a bit beyond its original name
{
    public Button move1Button;
    public Button move2Button;
    public Button move3Button;

    public Button strikeButton;
    public Button fleeButton;

    public void ChangeButtonText(Unit unit)
    {
        move1Button.GetComponentInChildren<Text>().text = MovesAndEffects.MoveList(unit.move1).Item1;
        move2Button.GetComponentInChildren<Text>().text = MovesAndEffects.MoveList(unit.move2).Item1;
        move3Button.GetComponentInChildren<Text>().text = MovesAndEffects.MoveList(unit.move3).Item1;
    }

    public void SetButtonsInactive()
    {
        move1Button.interactable = false;
        move2Button.interactable = false;
        move3Button.interactable = false;
        strikeButton.interactable = false;
        fleeButton.interactable = false;
    }

    public void SetButtonsActive()
    {
        move1Button.interactable = true;
        move2Button.interactable = true;
        move3Button.interactable = true;
        strikeButton.interactable = true;
        fleeButton.interactable = true;
    }
}
