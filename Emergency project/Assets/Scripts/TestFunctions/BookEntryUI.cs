using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class BookEntryUI : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private CanvasGroup canvasGroup;
    private Vector3 startPos;
    private Image image;
    public DialogueManage dialogueManage;
    public DialogueTrigger dialogueTrigger;
    
    bool isCase1;
    

    public UnityEvent<ResponseType> OnDragComplete;

    public ResponseType type;

    
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        startPos = transform.position;
        image = GetComponent<Image>();
        dialogueManage = GameObject.FindWithTag("DialogueManage").GetComponent<DialogueManage>();
        isCase1 = true;
        
    }

   


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.5f;
        transform.localScale += Vector3.one * 0.2f;
        startPos = transform.position;
        image.maskable = false; 
    }

    public void OnDrag(PointerEventData eventData)
    {
         //rectTrans.anchoredPosition += eventData.delta; 
        transform.position = Input.mousePosition; //OPTIONAL
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        transform.localScale -= Vector3.one * 0.2f;
        image.maskable = true;
        

        GameObject slotGo = GameObject.Find("TextSlot");
        
        float dist = Vector3.Distance(transform.position, slotGo.transform.position);
        
        if (dist <= 100f)
        {
            OnDragComplete.Invoke(type);
            MainCanvas.Instance.OnDragComplete(type);
            transform.position = slotGo.transform.position;
            
            Debug.Log("Complete");
            transform.position = startPos;

            if (isCase1 == true)
            {
                dialogueManage.DisPlayNextSentence("");
            }
            else
            {
                dialogueTrigger.TriggerDialogue1();
            }
        }
        else
        {
            transform.position = startPos;
        }

        

       
    }
   
}
