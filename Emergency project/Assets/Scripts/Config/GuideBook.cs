using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Book")]
public class GuideBook : ScriptableObject
{
    public string bookName;

    public List<GuideBookEntry> entries;
}

[System.Serializable]
public class GuideBookEntry
{
    public ResponseType type;
    public string content;
}

public enum ResponseType
{
    Hello,
    BasicInfo,
    RepeatQuestion,
    Comfort,
    MedicalAbility,
    RescueSituation,
    Burns,
    BreathingDifficulties,
    Syncope,
    Bleeding,
    Drowning,
    Fire,
    WildlifeProblem,
    Flooding,
    HumanBodyIssues,
    CarAccident,
    IntentionalInjury,
    Robbery,
    Kidnapping,
    Theft,
    Rape,
    Image
}


