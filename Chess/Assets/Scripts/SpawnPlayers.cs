using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPref;

    void Start()
    {
        SpownPlayers();
    }

    void SpownPlayers()
    {
        if(PhotonNetwork.CountOfPlayers == 1)
        {
            PhotonNetwork.Instantiate(playerPref.name, Vector3.zero, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(playerPref.name, Vector3.zero, Quaternion.identity);
        }
    }
}
