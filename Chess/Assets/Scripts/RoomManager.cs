using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    int startPlayers;
    
    public TMP_Text slot1;
    public TMP_Text slot2;

    private void Start() 
    {

    }

    private void Update() 
    {

        SetChallenger();

        if(startPlayers != PhotonNetwork.PlayerList.Length)
        {
            Debug.Log("Updating...");
            startPlayers = PhotonNetwork.PlayerList.Length;
        }

    }

    public void SetChallenger()
    {
        if(PhotonNetwork.PlayerList.Length <= 1)
        {
            SetPlayer.Set(slot1);
        } else 
        {
            SetPlayer.Set(slot2);
        }

        startPlayers = PhotonNetwork.PlayerList.Length;
        
    }

    [PunRPC]
    public void Player1()
    {
        slot1.text = PhotonNetwork.NickName;
    }

    [PunRPC]
    public void Player2()
    {
        slot2.text = PhotonNetwork.NickName;
    }
}
