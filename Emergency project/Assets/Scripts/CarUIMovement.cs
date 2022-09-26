using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUIMovement : MonoBehaviour
{
    public List<RectTransform> points;

    public float speed = 2;

    Vector2 endPoint;

    RectTransform rectTrans;

    Vector2 currentDir;

    int currIndex = 0;

    bool isStart = true;



    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        endPoint = points[currIndex].anchoredPosition;
        Vector2 dir = endPoint - rectTrans.anchoredPosition;
        currentDir = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //use lerp for movement

        if(Vector2.Distance(rectTrans.anchoredPosition, endPoint) > 5)
        {
            rectTrans.anchoredPosition += currentDir * speed * Time.deltaTime;
        }
        else if(currIndex + 1 < points.Count)
        {
            endPoint = points[++currIndex].anchoredPosition;
            Vector2 dir = endPoint - rectTrans.anchoredPosition;
            currentDir = dir.normalized;
        }
        else if(currIndex + 1 == points.Count && isStart)
        {
            Debug.Log("End");
            isStart = false;
        }
    }
}
