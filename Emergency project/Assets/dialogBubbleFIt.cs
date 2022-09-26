using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogBubbleFIt : MonoBehaviour
{
    public void FontAreaChanges(Text text)
    {
        RectTransform rect = text.GetComponent<RectTransform>();
        // 获取Text的Size
        Vector2 v2 = rect.rect.size;
        // width保持不变
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, v2.x);
        // 动态设置height
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, text.preferredHeight);
    }

}
