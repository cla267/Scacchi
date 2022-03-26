using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject panels;

#region PanelsVariables
    GameObject loadingPanel;
    GameObject mainMenuPanel;
    GameObject roomsPanel;
    GameObject settingsPanel;
    GameObject namePanel;
#endregion

    void Start() 
    {
        setPanels();
    }

    void Update()
    {
        
    }

    void LoadPanel(GameObject selected)
    {
        for(int i = 0; i < panels.transform.childCount; i++)
        {
            if(selected.transform.GetSiblingIndex() == i)
            {
                selected.SetActive(true);
            }else
            {
                panels.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public int ActivePanel()
    {
        if(loadingPanel.activeSelf)
        {
            return 1;
        }else if(mainMenuPanel.activeSelf)
        {
            return 2;
        }else if(roomsPanel.activeSelf)
        {
            return 3;
        }else if(settingsPanel.activeSelf)
        {
            return 4;
        }else if(namePanel.activeSelf)
        {
            return 5;
        }else
        {
            return 0;
        }
    }

    void setPanels()
    {
        loadingPanel = panels.transform.GetChild(0).gameObject;
        mainMenuPanel = panels.transform.GetChild(1).gameObject;
        roomsPanel = panels.transform.GetChild(2).gameObject;
        settingsPanel = panels.transform.GetChild(3).gameObject;
        namePanel = panels.transform.GetChild(4).gameObject;
    }
}
