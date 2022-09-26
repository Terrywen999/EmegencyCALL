using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Case", menuName = "Config/Case", order = 1)]
public class Case : ScriptableObject
{
    public string[] callerName;

    public int knowCallerName = -1;

    public string[] address;
    public int knowAddress = -1;

    public string[] info;
    public int knowInfo = -1;


    public int time;

    public DialogConfig startDialog;

    public string wrongResponse;

    public Vector2[] carPositions;

    public bool police;
    public bool ambulance;
    public bool fire;
    public bool fake;

    // when send wrong answers, the cost times
    public int wrongNameTime;
    public int wrongInfoTime;
    public int wrongAddressTime;
    public int wrongTrafficTime;

    public Image image;

    public float score;
}


