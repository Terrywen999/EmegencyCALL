using UnityEngine;
using UnityEngine.UI;
using System.Collections; 



public class AcceptPhone : MonoBehaviour
{
    public Button AcceptButton;
    public Timer timer; 
    void Start()
    {
        Button btn = AcceptButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick); 
        timer = GetComponent<Timer>();
    }

    void TaskOnClick()
    {
        
    }
}
