using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptButton : MonoBehaviour
{

    public DialogueManage dialogueManage;
    
    public void Accept()
    {
        if(GameManager.Instance.currentCaseIndex ==0)
        {
            dialogueManage.DisPlayNextSentence("Accept");
        }
        if(GameManager.Instance.currentCaseIndex == 1)
        {
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue1();
        }
        if(GameManager.Instance.currentCaseIndex == 2)
        {
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue2();
        }
        if (GameManager.Instance.currentCaseIndex == 3)
        {
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue3();
        }
    }
}
