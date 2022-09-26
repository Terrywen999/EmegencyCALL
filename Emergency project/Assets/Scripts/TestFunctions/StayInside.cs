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
        // UI ����ʵ����
        var pos = rectTransform.anchoredPosition;

        // UI �Ĵ�С�ߴ�
        var size = rectTransform.sizeDelta / 2;

        // ������Ļ�ĳߴ�
        float xDistance = Screen.width / 2;
        float yDistance = Screen.height / 2;

        // ���� UI ���������Сֵ
        float x = Mathf.Clamp(pos.x, -xDistance + size.x, xDistance - size.x);
        float y = Mathf.Clamp(pos.y, -yDistance + size.y, yDistance - size.y);

        // ���� UI ����
        rectTransform.anchoredPosition = new Vector2(x, y);
    }
}
