using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogBubbleFIt : MonoBehaviour
{
    public void FontAreaChanges(Text text)
    {
        RectTransform rect = text.GetComponent<RectTransform>();
        // ��ȡText��Size
        Vector2 v2 = rect.rect.size;
        // width���ֲ���
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, v2.x);
        // ��̬����height
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, text.preferredHeight);
    }

}
