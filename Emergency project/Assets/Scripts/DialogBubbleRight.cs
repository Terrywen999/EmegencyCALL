using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBubbleRight : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI content;

    public RectTransform img;
    public float offset = 40f;
    bool setImage = false;
    public RectTransform obj;

    public void SetText(string text)
    {
        content.text = text;
    }

    void Update()
    {
        if (setImage == false)
        {
            RectTransform textForm = content.gameObject.GetComponent<RectTransform>();
            img.sizeDelta = new Vector2(img.sizeDelta.x, textForm.sizeDelta.y + offset);
            obj.sizeDelta = new Vector2(obj.sizeDelta.x, textForm.sizeDelta.y + offset);
            setImage = true;
        }


    }
}
