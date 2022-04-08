using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class SetName : MonoBehaviourPunCallbacks
{
    public TMP_Text texto;

    void Start()
    {
        texto.text = PhotonNetwork.NickName;
    }

    private void Update() 
    {
        texto.transform.position = transform.position;
    }
}
