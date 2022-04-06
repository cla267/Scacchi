using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ProvaPerchèPietroèStupido : MonoBehaviour
{
    public TMP_Text text;

    private void Update() 
    {
        int num = PhotonNetwork.PlayerList.Length;
        text.text = num.ToString();
    }
}
