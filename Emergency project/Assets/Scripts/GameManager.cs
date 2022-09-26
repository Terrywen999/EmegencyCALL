using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    public List<Case> cases;

    public int currentCaseIndex;

    public UnityEvent NextLevelStart;

    public float TotalScore = 0;

    public int day = 1;
   
    private void Start()
    {
        currentCaseIndex = 0;

        MainCanvas.Instance.InitCase(cases[currentCaseIndex]);

        
    }

    public void NextLevel()
    {
        currentCaseIndex += 1; 
        MainCanvas.Instance.InitCase(cases[currentCaseIndex]);
        NextLevelStart.Invoke();
    }

    public float DayFinish()
    {
        for (int i = 0; i < cases.Count; i++)
        {
            TotalScore += cases[i].score;
        }

        float avgScore = TotalScore / cases.Count;
        return avgScore;
    }

    public void RestartLevel()
    {
        currentCaseIndex = 0;

        MainCanvas.Instance.InitCase(cases[currentCaseIndex]);

        NextLevelStart.Invoke();
    }

}
