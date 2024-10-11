using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Realtime;

public class StartGame : MonoBehaviourPunCallbacks
{
    public GameObject button;
    PhotonView photonView;
    public TextMeshProUGUI[] playerNameText;
    public Image[] playerClassIcon;
    public Sprite[] spriteClass;
    public Image playerClassIconBig;
    public Sprite[] spriteClassBig;
    public GameObject[] playerOptions;

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
    }

    public void LoadMap()
    {
        photonView.RPC("LoadMapRPC", RpcTarget.All);
    }

    public void ChosePlayerClass(int number)
    {
        PlayerClass.klasa = number;
        Debug.Log(Multi.playerID-1);
        playerClassIcon[Multi.playerID-1].sprite = spriteClass[number];
        playerClassIconBig.sprite = spriteClassBig[number];
        photonView.RPC("updateKlas", RpcTarget.All, Multi.playerID, number);

    }

    [PunRPC]
    public void updateKlas(int id, int klasa)
    {
        playerClassIcon[id-1].sprite = spriteClass[klasa];
    }

    [PunRPC]
    public void LoadMapRPC()
    {
        SceneManager.LoadScene(2);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        int newPlayerID = newPlayer.ActorNumber;
        Debug.Log( "Player who joined: " + newPlayerID);
        playerOptions[newPlayerID - 1].SetActive(true);
        playerNameText[newPlayerID - 1].text = newPlayer.NickName;
    }



    public override void OnJoinedRoom()
    {
        Multi.playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log( "Your Player Number: " + Multi.playerID);

        playerOptions[Multi.playerID - 1].SetActive(true);
        playerNameText[Multi.playerID - 1].text = PhotonNetwork.NickName;

        photonView.RPC("SendName", RpcTarget.All, Multi.playerID);
    }

    [PunRPC]
    public void SendName(int playerID)
    {
        photonView.RPC("SendNameNext", RpcTarget.All, playerID, PhotonNetwork.NickName, Multi.playerID, PlayerClass.klasa);
    }

    [PunRPC]
    public void SendNameNext(int playerID, string name, int id, int klasa)
    {
        if(playerID == Multi.playerID)
        {
            playerOptions[id - 1].SetActive(true);
            playerNameText[id - 1].text = name;
            playerClassIcon[id - 1].sprite = spriteClass[klasa];
        }
    }

}
