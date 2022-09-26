using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogOptionUI : MonoBehaviour
{
    public Text optionText;
    public Button optionButton;

    DialogOption data;
    Action<DialogOption> action;

    public void Init(DialogOption data, Action<DialogOption> onClickEvent)
    {
        this.data = data;
        action = onClickEvent;
        optionButton.onClick.AddListener(OnClick);

        //optionText.text = data.text;
    }

    void OnClick()
    {
        action.Invoke(data);
    }
}
