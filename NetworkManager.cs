using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [Header("UI")]
    public TextMeshProUGUI nickname;
    public Text textConnectLog;
    public Text textPlayerList;
    void Start()
    {
        Screen.SetResolution(960, 600, false);

        nickname = GameObject.Find("Canvas/Nickname").GetComponent<TextMeshProUGUI>();
        textConnectLog = GameObject.Find("Canvas/TextConnectLog").GetComponent<Text>();
        textPlayerList = GameObject.Find("Canvas/TextPlayerList").GetComponent<Text>();

        textConnectLog.text = "���ӷα�\n";
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;

        PhotonNetwork.LocalPlayer.NickName = nickname.text;
        PhotonNetwork.JoinOrCreateRoom("Room1", options, null);
    }

    public override void OnJoinedRoom()
    {
        updatePlayer();
        textConnectLog.text += nickname.text;
        textConnectLog.text += " ���� �濡 �����Ͽ����ϴ�.\n";
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        updatePlayer();
        textConnectLog.text += newPlayer.NickName;
        textConnectLog.text += " ���� �����Ͽ����ϴ�.\n";
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        updatePlayer();
        textConnectLog.text += otherPlayer.NickName;
        textConnectLog.text += " ���� �����Ͽ����ϴ�.\n";
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    void updatePlayer()
    {
        textPlayerList.text = "������";
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            textPlayerList.text += "\n";
            textPlayerList.text += PhotonNetwork.PlayerList[i].NickName;
        }
    }

}
