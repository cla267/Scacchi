using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class SetPlayer : MonoBehaviour
{
    public static PhotonView photonView;
    static TMP_Text slot;

    private void Start() {
        photonView = GetComponent<PhotonView>();
    }

    public static void Set(TMP_Text _slot)
    {
        slot = _slot;
        photonView.RPC("Erik", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void Erik()
    {
        slot.text = PhotonNetwork.NickName;
    }
}
