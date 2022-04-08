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
        SetPlayer();
    }

    private void Update() 
    {
        if(PhotonNetwork.CountOfPlayers != startPlayers)
        {
            Debug.Log("Updating...");
        }
    }

    void SetPlayer()
    {
        startPlayers = PhotonNetwork.CountOfPlayers;

        for(int i = 1; i < 2; i++)
        {
            Debug.Log(slot1.text.Length + "      " + slot1.text);
            if(i == 1)
            {
                if(slot1.text.ToLower() == "null" || slot1.text.Length == 0f)
                {
                    slot1.text = PhotonNetwork.NickName;
                    print("lol");
                } else {}
            } else
            {
                print("lol2");
                slot2.text = PhotonNetwork.NickName;
            }
        }
    }
}
