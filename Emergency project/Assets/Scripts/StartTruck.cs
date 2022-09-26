using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Utility;
using TMPro;

public class StartTruck : MonoBehaviour {
    public GameObject car;
    public float carSpeed = 15f;
    public GameObject bubbleGroup;
    public GameObject[] allBubbles;
    public GameObject bubble;
    public bool carMoving = false;
    public float bubbleDelayTime = 3f;
    public int maxBubbleNum = 3;

    public CinemachineSmoothPath carMovePath;

    public int bubbleTimes = 2;
    public int bubbleCurrentTime = 1;
    public bool noBubbleArea = false;

    public Animator mapText;

    public GameObject mapTextT;

    public TextMeshProUGUI scoreText;

   

    public GameObject showScore;
    CinemachineDollyCart cart;
    
    int checkCount = 0;

    public bool arrives = false;

    public Timer timer; 
    void Start() 
    {
        cart = car.GetComponent<CinemachineDollyCart>();
        timer.onTimeEnd.AddListener(StopCarWhenGameOver);

        if (bubbleGroup.activeInHierarchy == true)
        {
            bubbleGroup.SetActive(false);
        }
    }

    // when the form2 button clicked
    // start to move the car
    public void StartCarMovement() 
    {
        if (car.activeInHierarchy == false) 
        {
            car.SetActive(true);
            carMoving = true;
            cart.SetCartPosition(0);

            mapText.Play("MapText");
            // start coroutine, set timer for bubbles;
            StartCoroutine(BubbleDelay(bubbleDelayTime));
            arrives = false;
            noBubbleArea = false;
        }
    }

    IEnumerator BubbleDelay(float time) 
    {
        yield return new WaitForSeconds(time);

        if (noBubbleArea == false) 
        {
            // set the amount of the bubbles
            int randomNum = Random.Range(1,maxBubbleNum);

            allBubbles = new GameObject[randomNum];

            // randomly generate bubbles
            for (int i = 0; i < randomNum; i++) {
                // set the range where the bubble appears
                float randomPos = Random.Range(cart.m_Position + 50f, cart.m_Position + 80f); // ahead the cart 20 - 100 
                GameObject oneBubble = Instantiate(bubble, bubbleGroup.transform);
                oneBubble.GetComponent<CinemachineDollyCart>().m_Path = carMovePath;
                oneBubble.GetComponent<CinemachineDollyCart>().m_Position = randomPos;
                allBubbles[i] = oneBubble;
            }

            // adjust the angle of the button to ensure clickable
            StartCoroutine(AdjustAngle());

            // show bubbles
            bubbleGroup.SetActive(true);

            // stop the car
            carMoving = false;
        }
    }

    IEnumerator AdjustAngle() {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < allBubbles.Length; i ++) {
            GameObject oneBubble = allBubbles[i];
            oneBubble.transform.Find("Image").localRotation = Quaternion.Euler(0f, oneBubble.GetComponent<RectTransform>().eulerAngles.y * (-1), 0f);
            
        }
        
    }

    // According to the path set in case to set up the path
    public void SetUpPath(Case newCase) {
        CinemachineSmoothPath.Waypoint[] wps = new CinemachineSmoothPath.Waypoint[newCase.carPositions.Length];
        for (int i = 0; i < newCase.carPositions.Length; i ++) {
            CinemachineSmoothPath.Waypoint wp = new CinemachineSmoothPath.Waypoint();
            wp.position = new Vector3(newCase.carPositions[i].x, newCase.carPositions[i].y, 0f);
            wps[i] = wp;
        }
        carMovePath.InvalidateDistanceCache();
        carMovePath.m_Waypoints = wps;
        Debug.Log(wps.Length);

    }
    

    // count how many times the bubble was clicked
    // if all bubbles were clicked, start the car
    public void CheckClickingBubbles() {
        checkCount += 1;
        // all bubbles clicked
        if (checkCount >= allBubbles.Length) {
            checkCount = 0;
            carMoving = true;
            if (bubbleCurrentTime < bubbleTimes) {
                StartCoroutine(BubbleDelay(bubbleDelayTime));
                bubbleCurrentTime += 1;
            }
        }
    }

    void Update() {
        if (carMoving) {
            cart.SetCartPosition(cart.m_Position + carSpeed * Time.deltaTime);    
        }
        
        if (Mathf.Abs(carMovePath.PathLength - cart.m_Position) < 50) {
            noBubbleArea = true;
        }

        //arrives end 
        if (arrives == false && Mathf.Abs(carMovePath.PathLength - cart.m_Position) < 0.01)
        {
            Debug.Log("HELLO WORLD");
            float score = (float)timer.remainingDuration * 100 / (float)MainCanvas.Instance.GetCurrentCase().time;
            MainCanvas.Instance.GetCurrentCase().score = score;
            scoreText.text = MainCanvas.Instance.GetCurrentCase().score.ToString("F0");  
            showScore.SetActive(true);
            StartCoroutine(closeScoreWindow());
            if ((GameManager.Instance.currentCaseIndex + 1) == GameManager.Instance.cases.Count)
            {
                Debug.Log("day finish");
                gameObject.GetComponent<DayFinish>().dayFinish();
            }
            else
            {
                GameManager.Instance.NextLevel();
            }

            
            arrives = true; 
            car.SetActive(false);
            mapTextT.SetActive(false);
            bubbleCurrentTime = 1;
          
            
        }

       
    }


    public void StopCarWhenGameOver()
    {
        car.SetActive(false);
        mapTextT.SetActive(false);
        bubbleGroup.SetActive(false);
        bubbleCurrentTime = 1;
    }

    IEnumerator closeScoreWindow()
    {
        yield return new WaitForSeconds(1.5f);
        showScore.SetActive(false);
    }
}
