using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class MainCanvas : Singleton<MainCanvas>
{
    public Button acceptPhoneButton;

    public GameObject AcceptWindows;

    public Timer timer;

    public GameObject GameOver;

    private Case currentCase;

    private DialogConfig currentDialogue;

    private DialogOption currDialogOption;

    public ChatCanvas chatCanvas;

    public GuideBook book;

    public PanelManager panelCanvas;
    public ObjectPool objectPool;

    public DialogueManage dialogueManage;
    public GameObject arrow;
    

    public GameObject map;

    public AudioSource ringring;

    public bool search; 
    private void Start()
    {
        acceptPhoneButton.onClick.AddListener(OnAcceptPhone);
        timer.onTimeEnd.AddListener(OnTimeEnd);
        GameOver.SetActive(false);
        arrow.SetActive(false);
        GameManager.Instance.NextLevelStart.AddListener(TurnOnAcceptWindow);

    }

    public void InitCase(Case newCase)
    {
        if (newCase.fake == false)
        {
            newCase.knowCallerName = -1;
            newCase.knowInfo = -1;
            newCase.knowAddress = -1;
        }
        else
        {
            newCase.knowCallerName = 0;
            newCase.knowInfo = 0;
            newCase.knowAddress = 0;
        }
            Debug.Log(newCase.address);
        currentCase = newCase;
        currentDialogue = currentCase.startDialog;
        map.GetComponent<StartTruck>().SetUpPath(newCase);
        ResetChatCanvas();
        if (GameManager.Instance.currentCaseIndex != 0)
        { ringring.Play(); }
        timer.StopAndReset();

       

    }

    void OnAcceptPhone()
    {

        timer.gameObject.SetActive(true);
        if (dialogueManage.isTutorial == true)
        {
            arrow.SetActive(true);
        }

        StartCoroutine (WindowClose());

        
    }

    IEnumerator WindowClose()
    {
        yield return new WaitForSeconds(0.2f); 
        AcceptWindows.gameObject.SetActive(false);
        timer.animator.Play("CountDown"); 
        timer.SetUpTimer(currentCase.time);
        ringring.Stop();
        if (dialogueManage.isTutorial == true)
        {
            dialogueManage.arrowMove.Play("ArrowMovement");
        }
        

    }
    void OnTimeEnd()
    {
        GameOver.SetActive(true);
        InitCase(currentCase);
    }

    public void OnDragComplete(ResponseType type)
    {
        //find response from character
        string response = HandleResponse(type);
        chatCanvas.AddChatBubbleRight(response);

        //response from caller
        if (response != currentCase.wrongResponse)
        {
            List<DialogEntry> entries = currentDialogue.dialogEntries;

            foreach (DialogEntry entry in entries)
            {
                StartCoroutine(ShowNext(entry,type));
                

                //get next dialog
                currentDialogue = currDialogOption.config;
            }


        }
    }
        IEnumerator ShowNext(DialogEntry entry, ResponseType type)
        {

            yield return new WaitForSeconds(1f);
            Debug.Log("After 1s");

            chatCanvas.AddChatBubbleLeft(entry.text, type);

        }


       public string HandleResponse(ResponseType type)
        {
            foreach (DialogOption option in currentDialogue.dialogOptions)
            {
                if (option.responseType == type)
                {

                    currDialogOption = option;

                    return option.text;

                }


            }

            return currentCase.wrongResponse;
        }

    public Case GetCurrentCase()
    {
        return currentCase;
    }


    public void ResetChatCanvas()
    {
        chatCanvas.Clear();
        objectPool.Clear();
        dialogueManage.StopAllAnimation();
    }

    public void TurnOnAcceptWindow()
    {
       AcceptWindows.SetActive(true);
    }

    
}
