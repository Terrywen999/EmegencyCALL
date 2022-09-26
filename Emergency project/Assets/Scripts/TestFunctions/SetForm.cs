using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SetForm : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI address;
    public TextMeshProUGUI info;

    //public PanelManager panelManager;
    public Transform panelManager;
    public DialogueManage dialogueManage;
   
    //public GameObject AcceptWindow;

    public Toggle ambulance;
    public Toggle police;
    public Toggle fire;
    public Toggle fake;
    
    public Timer timer;

    public GameObject mapText;

    private void Start()
    {
        //AcceptWindow.SetActive(false);
        mapText = GameObject.FindWithTag("mapText");
        //mapText.SetActive(false);
        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();
        panelManager = GameObject.FindWithTag("PanelManager").transform;
        dialogueManage = GameObject.FindWithTag("DialogueManage").GetComponent<DialogueManage>();
    }

    void OnEnable()
    {
        Case currentCase = MainCanvas.Instance.GetCurrentCase();
        if (currentCase.knowCallerName != -1)
        {
            nameText.text = "Name: " + currentCase.callerName[currentCase.knowCallerName];
        }
        else
        {
            nameText.text = "Name: ";
        }

        if (currentCase.knowAddress != -1)
        {
            address.text = "Address: " + currentCase.address[currentCase.knowAddress];
        }
        else
        {
            address.text = "Address: ";
        }


        if (currentCase.knowInfo != -1)
        {
            info.text = "Info: " + currentCase.info[currentCase.knowInfo];
        }
        else
        {
            info.text = "Info: ";
        }
    }

    void Update()
    {
        Case currentCase = MainCanvas.Instance.GetCurrentCase();
        if (currentCase.knowCallerName != -1)
        {
            nameText.text = "Name: " + currentCase.callerName[currentCase.knowCallerName];
        }
        else
        {
            nameText.text = "Name: ";
        }

        if (currentCase.knowAddress != -1)
        {
            address.text = "Address: " + currentCase.address[currentCase.knowAddress];
        }
        else
        {
            address.text = "Address: ";
        }


        if (currentCase.knowInfo != -1)
        {
            info.text = "Info: " + currentCase.info[currentCase.knowInfo];
        }
        else
        {
            info.text = "Info: ";
        }
    }

    public void SendForm()
    {
        //check success or not
        bool success = true;
        Case currentCase = MainCanvas.Instance.GetCurrentCase();

        if (currentCase.knowInfo != 0)
        {
            timer.remainingDuration -= currentCase.wrongInfoTime;
            success = false;
        }

        if (currentCase.knowAddress != 0)
        {
            timer.remainingDuration -= currentCase.wrongAddressTime;
            success = false;
        }

        if (currentCase.knowCallerName != 0)
        {
            timer.remainingDuration -= currentCase.wrongNameTime;
            success = false;
        }

        if (currentCase.fire != fire.isOn || currentCase.ambulance != ambulance.isOn || currentCase.police != police.isOn || currentCase.fake != fake.isOn)
        {
            timer.remainingDuration -= currentCase.wrongTrafficTime;
            success = false;
        }
        //play animation
        if (success == true)
        {
            
            GameObject map = GameObject.FindWithTag("Map");


            if (map != null)
            {
                map.GetComponent<StartTruck>().StartCarMovement();
                dialogueManage.DisPlayNextSentence("");
                for (int i = panelManager.childCount - 1; i >= 0; i--)
                {
                    Destroy(panelManager.GetChild(i).gameObject);
                    //panelManagerT.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
        //reset canvas

        
        //Next level
        //GameManager.Instance.NextLevel();
        //StartCoroutine(AcceptPhoneCall());
        
    }

   //IEnumerator AcceptPhoneCall()
    //{
     //   yield return new WaitForSeconds(2f) ;
      //  AcceptWindow.SetActive(true); 
        
   // }


}
 