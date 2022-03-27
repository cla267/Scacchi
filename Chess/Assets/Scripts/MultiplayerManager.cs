using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    public GameObject panels;

    [SerializeField] TMP_Text inputNameText;

    [SerializeField] TMP_Text inputRoomText;

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
        LoadPanel(loadingPanel);
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
        if(ActivePanel() == 1){loadingPanel.GetComponent<Animator>().SetBool("isLoading", true);}
        else{loadingPanel.GetComponent<Animator>().SetBool("isLoading", false);}

        if(inputNameText.text.Contains(" ")){namePanel.transform.GetChild(2).GetComponent<Button>().enabled = false;}
        else{namePanel.transform.GetChild(2).GetComponent<Button>().enabled = true;}
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

    public void EnterUsername()
    {
        PhotonNetwork.NickName = inputNameText.text;
        LoadPanel(mainMenuPanel);
    }

    public void GoBack()
    {
        LoadPanel(loadingPanel);
        PhotonNetwork.Disconnect();
    }

    public void EnterRoomsMenu()
    {
        LoadPanel(roomsPanel);
    }

    public void EnterRoom()
    {
        PhotonNetwork.JoinRoom(inputRoomText.ToString());
    }

    public void BackToMenu()
    {
        LoadPanel(mainMenuPanel);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        LoadPanel(namePanel);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        if(message == "Game does not exist")
        {
            PhotonNetwork.CreateRoom(inputRoomText.ToString());
        }else
        {
            Debug.LogError("Peter è stupido");
        }
    }
    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene(2);
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
