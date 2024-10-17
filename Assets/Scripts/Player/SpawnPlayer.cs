using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//
public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] player;
    public Vector2 position;

    void Start()
    {
        if(PlayerClass.klasa == 0)
        {
            PlayerClass.klasa = Random.Range(1,5);
        }
        GameObject playerInstance = PhotonNetwork.Instantiate(player[PlayerClass.klasa-1].name, position, Quaternion.identity);
        playerInstance.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
    }
}
