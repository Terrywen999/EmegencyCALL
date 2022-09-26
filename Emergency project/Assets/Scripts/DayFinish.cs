using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayFinish : MonoBehaviour
{

    public Animator star;
    public GameObject dayFinishPanel;
    public GameObject AcceptWindow;

    public ChatCanvas chatCanvas;

    public GameObject timer;

    public GameObject fire;
    public GameObject crime;

    public void dayFinish()
    {

        dayFinishPanel.SetActive(true);

        if (GameManager.Instance.DayFinish() > 70)
        {
            star.Play("Star");
            AcceptWindow.SetActive(false);
        }
        else if  (GameManager.Instance.DayFinish() >50 )
        {
            star.Play("Star2");
            AcceptWindow.SetActive(false);
        }
        else if (GameManager.Instance.DayFinish() > 30)
        {
            star.Play("Star3");
            AcceptWindow.SetActive(false);
        }

        GameManager.Instance.day += 1;
        GameManager.Instance.cases.Clear();

       
        
        if (GameManager.Instance.day == 2)
        {
            for (int i = 1; i < 7; i++)
            {
                string name = "Day2Case" + i.ToString();
                GameManager.Instance.cases.Add(Resources.Load<Case>(name));
            }
            chatCanvas.Clear();
            timer.SetActive(false);
            fire.SetActive(true);
            crime.SetActive(true);
        }


        if (GameManager.Instance.day == 3)
        {
            for (int i = 1; i < 7; i++)
            {
                string name = "Day3Case" + i.ToString();
                GameManager.Instance.cases.Add(Resources.Load<Case>(name));
            }
            chatCanvas.Clear();
            timer.SetActive(false);
        }


       
        
    }



}
