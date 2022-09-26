using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    [SerializeField] Text countdownText;
    [SerializeField] private Image uiFill;

    public int Duration; 
    public int remainingDuration;

    public Animator animator;
    public UnityEvent onTimeEnd;

    float currentTime;

    bool isEnd;

    private void Start()
    {
        gameObject.SetActive(true);       
    }


    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer()); 
    }


    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            countdownText.text = $"{remainingDuration / 60} : {remainingDuration % 60}";
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f); 
        }
    }
     
    public void SetUpTimer(float time)
    {
        //gameObject.SetActive(true);
        currentTime = time;
        isEnd = false;
        //Being(Duration);

        Duration = (int)currentTime;
        Being((int)currentTime);

    }

    public void StopAndReset()
    {
        gameObject.SetActive(false);
        isEnd = true;
    }

     private void Update()
    {
        //currentTime -= 1 * Time.deltaTime;
        //countdownText.text = currentTime.ToString("0"); 

        if (!isEnd && remainingDuration <= 0)
        {
            gameObject.SetActive(false); 
            onTimeEnd.Invoke();
            isEnd = true;
        }
    }
}
