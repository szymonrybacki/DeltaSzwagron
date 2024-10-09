using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject button;
    public Text numberPlayers;
    PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if(Multi.playerID != 1)
            button.SetActive(false);
        else
            button.SetActive(true);
        numberPlayers.text = "Liczba graczy w lobby: " + PhotonNetwork.CountOfPlayersInRooms + "/4";
    }

    public void LoadMap()
    {
        photonView.RPC("LoadMapRPC", RpcTarget.All);
    }

    [PunRPC]
    public void LoadMapRPC()
    {
        SceneManager.LoadScene(2);
    }
}
