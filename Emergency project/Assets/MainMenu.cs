using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{

    [SerializeField] private AudioSource buttonClick;
    public GameObject mainMenu;
    
 
    public void PlayGame()
    {
      
        mainMenu.SetActive(false);
        

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void clickSound()
    {
        buttonClick.Play();
    }
   
}
