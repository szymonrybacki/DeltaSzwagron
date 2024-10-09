using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;

    public Vector2 position;

    void Start()
    {
        GameObject playerInstance = PhotonNetwork.Instantiate(player.name, position, Quaternion.identity);
        playerInstance.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
    }
}
