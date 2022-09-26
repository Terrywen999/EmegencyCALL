using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue1;

    public Dialogue dialogue2;


    public Dialogue dialogue3;
    public void TriggerDialogue1()
    {

       
        FindObjectOfType<DialogueManage>().StartDialogue(dialogue1);



    }

    public void TriggerDialogue2()
    {

        FindObjectOfType<DialogueManage>().StartDialogue(dialogue2);

    }

    public void TriggerDialogue3()
    {

        FindObjectOfType<DialogueManage>().StartDialogue(dialogue3);

    }
    public void Restart()
    {
        MainCanvas.Instance.AcceptWindows.SetActive(true);
        if (GameManager.Instance.currentCaseIndex == 0 && GameManager.Instance.day ==1)
        {
            TriggerDialogue1();

        }
    }
}
