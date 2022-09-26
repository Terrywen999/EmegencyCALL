using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DialogBubbleLeft : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI content;

    public RectTransform img;
    public float offset = 40f;

    ResponseType type;
    bool setImage = false;

    
    public void SetType(ResponseType resType)
    {
        this.type = resType; 
    }

    void Update()
    {
        if (setImage == false)
        {
            RectTransform textForm = content.gameObject.GetComponent<RectTransform>();
            img.sizeDelta = new Vector2(img.sizeDelta.x, textForm.sizeDelta.y + offset);
          
            setImage = true;
           
            

        }
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(content, Input.mousePosition, null);
        Debug.Log("Hello3");
        if (linkIndex > -1)
        {
            var linkInfo = content.textInfo.linkInfo[linkIndex];
            var linkId = linkInfo.GetLinkID();
            Debug.Log("Hello");
            switch (linkId)
            {
                case "cantReadName":
                    string linkContent1 = linkInfo.GetLinkText();
                    if (MainCanvas.Instance.search == true)
                    {
                        Debug.Log("Hello2");
                        content.text = content.text.Replace("cantReadName", "name");
                        content.text = content.text.Replace(linkContent1, MainCanvas.Instance.GetCurrentCase().callerName[0]);
                    }

                    break;

                case "cantReadAddress":
                    string linkContent2 = linkInfo.GetLinkText();
                    {
                        content.text = content.text.Replace("cantReadAddress", "name");
                        content.text = content.text.Replace(linkContent2, MainCanvas.Instance.GetCurrentCase().callerName[0]);
                    }
                    break;

                case "cantReadInfo":
                    string linkContent3 = linkInfo.GetLinkText();
                    {
                        content.text = content.text.Replace("cantReadAddress", "name");
                        content.text = content.text.Replace(linkContent3, MainCanvas.Instance.GetCurrentCase().callerName[0]);
                    }
                    break;
            }
        }


    }

    public void SetText(string text)
    {
        content.text = text; 
    
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(content, Input.mousePosition, null);
            if(linkIndex > -1)
            {
                var linkInfo = content.textInfo.linkInfo[linkIndex];
                var linkId = linkInfo.GetLinkID();

                switch (linkId)
                {
                    case "name":
                        MainCanvas.Instance.GetCurrentCase().knowCallerName = 0;
                        break;
                    case "address":
                        MainCanvas.Instance.GetCurrentCase().knowAddress = 0;
                        break;
                    case "info":
                        MainCanvas.Instance.GetCurrentCase().knowInfo = 0;
                        break;
                    


                }
            }
        }
    }
}
