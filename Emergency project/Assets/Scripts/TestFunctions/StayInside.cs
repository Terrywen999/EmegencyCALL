using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StayInside : MonoBehaviour
{
    public Image img;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = img.GetComponent<RectTransform>();
    }

    private void Update()
    {
        // UI 的真实坐标
        var pos = rectTransform.anchoredPosition;

        // UI 的大小尺寸
        var size = rectTransform.sizeDelta / 2;

        // 计算屏幕的尺寸
        float xDistance = Screen.width / 2;
        float yDistance = Screen.height / 2;

        // 限制 UI 坐标最大最小值
        float x = Mathf.Clamp(pos.x, -xDistance + size.x, xDistance - size.x);
        float y = Mathf.Clamp(pos.y, -yDistance + size.y, yDistance - size.y);

        // 调整 UI 坐标
        rectTransform.anchoredPosition = new Vector2(x, y);
    }
}
