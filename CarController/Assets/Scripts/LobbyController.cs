using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LobbyController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject cancelButton;
    [SerializeField]
    private int RoomSize;
    void Start()
    {

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        PhotonNetwork.AutomaticallySyncScene = true;
        startButton.SetActive(true);
    }

    public void QuickStart()
    {
        Debug.Log("Quickstart!");
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("failed to login to room");

        CreateRoom();
    }

    void CreateRoom()
    { 
        Debug.Log("Creating room...");
        int roomNumber = Random.Range(0, 100);
        RoomOptions roomOps = new RoomOptions();
        roomOps.IsVisible = true; 
        roomOps.IsOpen = true;
        roomOps.MaxPlayers = (byte)RoomSize;
        PhotonNetwork.CreateRoom("Room: " + roomNumber, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("creating room failed");
    }

    public void Cancel()
    {
        Debug.Log("cancellin...g");
        cancelButton.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
