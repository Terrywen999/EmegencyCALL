using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class search : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private CanvasGroup canvasGroup;
    private Vector3 startPos;
    private Image image;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        startPos = transform.position;
        image = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.5f;
        transform.localScale += Vector3.one * 0.2f;
        startPos = transform.position;
        image.maskable = false;
        MainCanvas.Instance.search = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        transform.localScale -= Vector3.one * 0.2f;
        image.maskable = true;
        transform.position = startPos;
        MainCanvas.Instance.search = false;
        GameObject dialogueBubbleLeft = GameObject.Find("");
    }
}
