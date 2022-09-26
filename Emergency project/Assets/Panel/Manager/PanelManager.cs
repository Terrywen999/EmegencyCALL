using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelManager : Singleton<PanelManager>
{
    //this is going to hold all of our instance 
    private List<PanelInstanceModel> _listInstances = new List<PanelInstanceModel>();

        private ObjectPool _objectPool;

    
    private RectTransform rectTransform;
    

    private void Start()
    {
        _objectPool = ObjectPool.Instance; 
    }


    public void ShowPanel(string panelId, PanelShowBehavior behaviour = PanelShowBehavior.KEEP_PREVIOUS)
    {
        float delayTIme = 0.2f;
        StartCoroutine(ShowPanel(panelId, PanelShowBehavior.KEEP_PREVIOUS, delayTIme));
        

    }

    IEnumerator ShowPanel(string panelId, PanelShowBehavior behaviour, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GameObject panelInstance = _objectPool.GetGameObjectFromPool(panelId);



        if (panelInstance != null)
        {
            if(behaviour == PanelShowBehavior.HIDE_PREVIOUS && GetAmountPanelsInQueue() > 0)
            {
               
                var lastPanel = GetLastPanel();
                if(lastPanel != null)
                {
                    lastPanel.PanelInstance.SetActive(false); 
                }
            }
            //add this new panel to the scene
            _listInstances.Add(new PanelInstanceModel
            {
                PanelId = panelId,
                PanelInstance = panelInstance
            }); 
            StartCoroutine(ShowPanelDelay());
        }
        else
        {
            Debug.LogWarning($"Trying to use panelId = {panelId}, but this is not found in Panels");
           
        } 
    }
        IEnumerator ShowPanelDelay()
         {
        yield return new WaitForSeconds(1f);
        Debug.Log("wait 1s");

        
         }
    public void HideLastPanel(GameObject clickedPanel)
    {
        for(int i=0; i< _listInstances.Count; i ++)
        {
            if (_listInstances[i].PanelInstance == clickedPanel)
            {
                _listInstances.Remove(_listInstances[i]);
                _objectPool.PoolObject(clickedPanel);
            }
        }
    }

   


    PanelInstanceModel GetLastPanel()
    {
        return _listInstances[_listInstances.Count - 1];
    }
    //rutrn if any panel is showing  
    public bool AnyPnaelShowing()
    {
        return GetAmountPanelsInQueue() > 0;
    }
    //ruturns how many panels we have in queue. 
    public int GetAmountPanelsInQueue()
    {
        return _listInstances.Count; 
    }


    public void StayInside()
    {

    }
}
