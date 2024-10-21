using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    public GameObject[] player; 
    public Vector2 position; 

    private int playersReady = 0;

    void Start()
    {
        SetPlayerReady(true);

        CheckAllPlayersReady();
    }

    public void SetPlayerReady(bool isReady)    //TO będzie trzeba zmienić bo obecna werjsa jest mało autorska
    {
        ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
        playerProperties["ready"] = isReady;
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);
    }

    private void CheckAllPlayersReady()
    {
        int playerCount = PhotonNetwork.PlayerList.Length;

        playersReady = 0;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.CustomProperties.TryGetValue("ready", out object isReady) && (bool)isReady)
            {
                playersReady++;
            }
        }

        if (playersReady == playerCount)
        {
            AllPlayersReady();
        }
    }

    private void AllPlayersReady()
    {
        Debug.Log("Wszyscy gracze są gotowi! Tworzenie postaci...");

        if (PlayerClass.klasa == 0)
        {
            PlayerClass.klasa = Random.Range(1, 5);
        }

        GameObject playerInstance = PhotonNetwork.Instantiate(player[PlayerClass.klasa - 1].name, position, Quaternion.identity);
        playerInstance.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (changedProps.ContainsKey("ready"))
        {
            CheckAllPlayersReady();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        CheckAllPlayersReady();
    }
}
