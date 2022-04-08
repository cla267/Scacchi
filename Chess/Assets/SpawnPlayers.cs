using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPref;
    public Transform slot1;
    public Transform slot2;

    void Start()
    {
        SpownPlayers();
    }

    void SpownPlayers()
    {
        if(PhotonNetwork.CountOfPlayers == 1)
        {
            PhotonNetwork.Instantiate(playerPref.name, slot1.transform.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(playerPref.name, slot2.transform.position, Quaternion.identity);
        }
    }
}
