using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IBeginDragHandler //, IPointerDownHandler
{
    [SerializeField] private RectTransform dragRectTransform; 
   
    public RectTransform dragRangeRect;//拖拽限制范围Rect
    Vector2 offset;

    void Start() {
        dragRangeRect = GameObject.Find("/InterractiveCanvas/BackGround").GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(dragRangeRect, eventData.position, eventData.pressEventCamera, out localPoint))
        {
            offset = (Vector2)dragRectTransform.localPosition - localPoint;//算出开始拖拽时候鼠标点和 dragTarget的偏移量
        }
    }
   
    
    public void OnDrag(PointerEventData eventData)
    {
        //把鼠标点映射到dragRangeRect的局部坐标点
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(dragRangeRect, eventData.position, eventData.pressEventCamera, out localPoint))
        {
            dragRectTransform.localPosition = localPoint + offset;
        }
        
        //限制范围
        Vector2 min = dragRangeRect.rect.min - dragRectTransform.rect.min;
        Vector2 max = dragRangeRect.rect.max - dragRectTransform.rect.max;
        Vector3 pos = dragRectTransform.localPosition;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        dragRectTransform.localPosition = pos;
    }
}
