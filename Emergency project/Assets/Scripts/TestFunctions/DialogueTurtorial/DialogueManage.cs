using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManage : MonoBehaviour
{

    private Queue<string> sentences;

    public Animator animator;

    public Animator arrowMove;
    public Animator arrowMove2;
    public Animator arrowMove3;
    public Animator arrowMove4;

    public TextMeshProUGUI nameText;
    
    public TextMeshProUGUI dialogueText;

    public Button NextDialog;
    

    public GameObject AcceptWindow;

    public GameObject Arrow2;
    public GameObject Arrow;
    public GameObject Arrow3;
    public GameObject Arrow4;

    public GameObject chat;
    public GameObject map;
    public GameObject guide;
    public GameObject crime;
    public GameObject medical;
    public GameObject form;
    public GameObject fire;

    [SerializeField] private AudioSource ringing;
    [SerializeField] private AudioSource typing;

    public bool isTutorial = true; 

    void Start()
    {
        sentences = new Queue<string>();
        NextDialog.gameObject.SetActive(false);
        Arrow2.SetActive(false);
        Arrow3.SetActive(false);
        Arrow4.SetActive(false);

        crime.SetActive(false);
        fire.SetActive(false);
        medical.SetActive(false);
        

    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen" , true);
        NextDialog.gameObject.SetActive(true);
        

        Debug.Log("Starting conversation" + dialogue.name);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach ( string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisPlayNextSentence("");
    }
   
    public void DisPlayNextSentence(string buttonName)
    {
        if(sentences.Count == 0)
        {
            Arrow2.SetActive(false);
            isTutorial = false; 
            EndDialogue();
            return;
        }



        if(sentences.Count == 7)
        {
            map.SetActive(true);
            
        }

        if (sentences.Count ==6 && GameManager.Instance.currentCaseIndex == 1)
        {
            EndDialogue();
        }

        if (sentences.Count == 4 && GameManager.Instance.currentCaseIndex == 1)
        {
            RestartDialogue();
        }


        if (sentences.Count == 16)
        {
            AcceptWindow.SetActive(true);
            ringing.Play();
            EndDialogue();
        }

        if(sentences.Count == 15)
        {
            RestartDialogue();
        }

        if(sentences.Count == 14)
        {


            Arrow.SetActive(false);
            Arrow2.SetActive(true);
            arrowMove2.Play("ArrowMovement2");
            guide.SetActive(true); 
            //RestartDialogue();
        }

        if(sentences.Count == 13 )
        {
            
            Arrow2.SetActive(false);
            if (buttonName != "Guide")
            {
                return;
            }
        }

        if (sentences.Count == 12)
        {
          
           
        }

        if (sentences.Count == 11)
        {

            Arrow3.SetActive(true);
            arrowMove3.Play("ArrowMovement3");
            form.SetActive(true);
        }

        if (sentences.Count == 10)
        {

            Arrow3.SetActive(false);
        }

        if (sentences.Count == 9)
        {
            
            
            Arrow3.SetActive(false);
        }

        if (sentences.Count == 7)
        {
            Arrow4.SetActive(true);
            arrowMove4.Play("ArrowMovement4");
        }

        if (sentences.Count == 6)
        {
            Arrow4.SetActive(false);
            

        }

        if(sentences.Count ==5)
        {
            if (GameManager.Instance.currentCaseIndex == 2)
            {
                EndDialogue();
            }
        }

        if(sentences.Count == 3 &&GameManager.Instance.currentCaseIndex==2)
        {
            
               RestartDialogue();
            
        }



        if (sentences.Count == 3 && GameManager.Instance.currentCaseIndex == 3)

        { EndDialogue(); }
            
            if (sentences.Count == 2 && GameManager.Instance.currentCaseIndex == 3)
            {
               RestartDialogue();
                medical.SetActive(true);
            }
       
        
        typing.Play();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine (TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            
            yield return null;   
        }
        
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of Conversation");
    }

    void RestartDialogue()
    {
        animator.SetBool("IsOpen", true); 
    }

    public void StopAllAnimation()
    {
        if (Arrow2.activeInHierarchy == true)
        {
            Arrow2.SetActive(false);
        }

        if (Arrow3.activeInHierarchy == true)
        {
            Arrow3.SetActive(false);
        }

        if (Arrow4.activeInHierarchy == true)
        {
            Arrow4.SetActive(false);
        }
    }
}
