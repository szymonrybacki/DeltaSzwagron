using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Multi : MonoBehaviour
{
    public static int playerID;
    public static void AssignID()
    {
        playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log("Mój numer gracza to: " + playerID);
    }

}
