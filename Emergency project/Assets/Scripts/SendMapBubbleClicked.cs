using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMapBubbleClicked : MonoBehaviour
{
    GameObject map;

    private AudioSource popup;

    void Start() {
        map = GameObject.FindWithTag("Map");
    }


    public void BubbleClicked() {
        map.GetComponent<StartTruck>().CheckClickingBubbles();
        this.gameObject.SetActive(false);
        popup = GameObject.FindWithTag("popup").GetComponent<AudioSource>();
        popup.Play();
    }
}
