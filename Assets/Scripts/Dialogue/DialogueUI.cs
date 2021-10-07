using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//https://www.youtube.com/watch?v=RfLCzDzkvb0&list=PLCGaK2yqfY2IrJYnOnlgdmzWVUFXsRQXA&index=2
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private OverworldControls controls;
    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        controls = FindObjectOfType<OverworldControls>();

        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for(int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses)
                break;

            yield return new WaitUntil(() => controls.playerCS.Overworld.Select.ReadValue<float>() == 1);
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }                
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
