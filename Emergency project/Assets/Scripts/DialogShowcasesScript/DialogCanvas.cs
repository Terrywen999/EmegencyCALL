using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogCanvas : MonoBehaviour
{
    public DialogOptionUI optionUIPrefab;
    public Transform optionRoot;

    public Case testCase;

    public Text callerNameText;
    public Text dialogText;

    public Button nextButton;

    int dialogIndex = 0;

    DialogConfig currentDialog;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.onClick.AddListener(ShowNextDialog);

        callerNameText.text = testCase.callerName[0];

        currentDialog = testCase.startDialog;

        dialogIndex = 0;
        dialogText.text = currentDialog.dialogEntries[dialogIndex].text;
    }

    void ShowNextDialog()
    {
        dialogIndex++;
        dialogText.text = currentDialog.dialogEntries[dialogIndex].text;     

        //End of the dialog
        if(dialogIndex == currentDialog.dialogEntries.Count - 1)
        {
            ShowOptions(currentDialog.dialogOptions);
            nextButton.gameObject.SetActive(false);
        }
    }

    void ShowOptions(List<DialogOption> options)
    {
        foreach(DialogOption option in options)
        {
            DialogOptionUI optionUI = Instantiate(optionUIPrefab, optionRoot);
            optionUI.Init(option, OnOptionClick);
        }
    }

    void OnOptionClick(DialogOption option)
    {
       // Debug.Log(option.text);
        currentDialog = option.config;
        dialogIndex = 0;
        dialogText.text = currentDialog.dialogEntries[dialogIndex].text;
        nextButton.gameObject.SetActive(true);
        
        for(int i = optionRoot.childCount -1; i >= 0; i--)
        {
            Destroy(optionRoot.GetChild(i).gameObject);
        }
    }
}
