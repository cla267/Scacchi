using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    int startPlayers;

    public GameObject playerPref;
    
    public TMP_Text slot1;
    public TMP_Text slot2;

    private void Start() 
    {
        SetPlayer();
    }

    private void Update() 
    {
        if(startPlayers != PhotonNetwork.PlayerList.Length)
        {
            Debug.Log("Updating...");
            startPlayers = PhotonNetwork.PlayerList.Length;
            Debug.LogError(startPlayers);
        }

        print(startPlayers);
    }

    public void SetPlayer()
    {
        
        if(slot1.text.ToLower() == "null" || slot1.text.Length == 0f)
        {
            photonView.RPC("Player1", RpcTarget.AllBuffered);
        } else 
        {
            photonView.RPC("Player2", RpcTarget.AllBuffered);
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
