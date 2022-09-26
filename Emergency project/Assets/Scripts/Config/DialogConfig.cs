using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Dialog")]
public class DialogConfig : ScriptableObject
{
    public List<DialogEntry> dialogEntries;

    public List<DialogOption> dialogOptions;

    public static implicit operator DialogConfig(DialogOption v)
    {
        throw new NotImplementedException();
    }
}

[Serializable]
public class DialogEntry
{
    [TextArea(10, 20)]
    public string text;
}

[Serializable]
public class DialogOption
{
    public ResponseType responseType;

    public DialogConfig config;

    [TextArea(10, 20)]
    public string text;
}
