using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text textLabel;

    public bool IsOpen { get; private set; }

    private TypewriterEffect typewriterEffect;
    private ResponseHandler responseHandler;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogue();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        nameLabel.text = dialogueObject.name;
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        } 
        else
        {
            CloseDialogue();
        }

    }

    private void CloseDialogue()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        nameLabel.text = string.Empty;
        textLabel.text = string.Empty;
    }
}
