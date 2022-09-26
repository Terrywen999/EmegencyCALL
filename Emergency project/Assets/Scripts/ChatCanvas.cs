using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatCanvas : MonoBehaviour
{
    public Transform chatRoot;

    public DialogBubbleLeft chatPrefabLeft;

   public DialogBubbleRight chatPrefabRight;

    private AudioSource sentBack;
    private AudioSource sent;

    public void AddChatBubbleLeft(string text, ResponseType type)
    {
        DialogBubbleLeft obj = Instantiate(chatPrefabLeft, chatRoot);
        sentBack = GameObject.FindWithTag("sentBack").GetComponent<AudioSource>();
        obj.SetText(text);
        obj.SetType(type);
        sentBack.Play();
    }

    public void AddChatBubbleRight(string text)
    {
        DialogBubbleRight obj = Instantiate(chatPrefabRight, chatRoot);
        obj.SetText(text);
        sent = GameObject.FindWithTag("BookEntryUI").GetComponent<AudioSource>();
        sent.Play();
    }

    public void Clear()
    {
        for(int i = chatRoot.childCount - 1; i >= 0; i--)
        {
            Destroy(chatRoot.GetChild(i).gameObject);
        }
    }
}
