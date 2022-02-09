using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    public InputField NickNameInput;
    public GameObject DisconnectPanel;
    public GameObject ButtonManager;
    
    public GameObject ButtonCanvas;

    public GameObject ChatEventSystem;

    public GameObject ChatCanvas;

    public GameObject ChatController;


    //오늘 만든 변수
    public GameObject EscCanvas;
    public GameObject player;

    public ButtonEvent buttonEvent;
    public ChatTest chatTest;


    void Awake()
    {
        Screen.SetResolution(960, 540, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }
    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
    }

    public override void OnJoinedRoom()
    {
        DisconnectPanel.SetActive(false);
        ButtonManager.SetActive(true);
        ButtonCanvas.SetActive(true);

        ChatEventSystem.SetActive(true);
        ChatCanvas.SetActive(true);
        ChatController.SetActive(true);


        Spawn();
    }


    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        player = GameObject.FindWithTag("Player");
        buttonEvent.Start();
        chatTest.Start();
        print("마지막까지 됨");
    }

    //돌아가기 버튼
    public void Reuse()
    {
        EscCanvas.SetActive(false);
        ButtonManager.SetActive(true);
        ButtonCanvas.SetActive(true);

        ChatEventSystem.SetActive(true);
        ChatCanvas.SetActive(true);
        ChatController.SetActive(true);

        player.SetActive(true);
    }


    //나가기 버튼
    public void EscButton()
    {
        EscCanvas.SetActive(true);
        ButtonManager.SetActive(false);
        ButtonCanvas.SetActive(false);

        ChatEventSystem.SetActive(false);
        ChatCanvas.SetActive(false);
        ChatController.SetActive(false);

        player.SetActive(false);



    }


    //다시 한번 나가기 버튼 클릭시 수행
    public void DisConnect_Bum()
    {
        DisconnectPanel.SetActive(true);
        EscCanvas.SetActive(false);

        PhotonNetwork.Disconnect();

    }

    /*
    //게임에서 나가지기를 만들기
    void Update() {
         if (Input.GetKeyDown(KeyCode.Escape) && PhotonNetwork.IsConnected)
         {
            PhotonNetwork.Disconnect();
        

            DisconnectPanel.SetActive(true);
            ButtonManager.SetActive(false);
            ButtonCanvas.SetActive(false);

            ChatEventSystem.SetActive(false);
            ChatCanvas.SetActive(false);
            ChatController.SetActive(false);
        }
    }
    */

    //서버가 연결이 안되었을때 실행되는 함수
    public override void OnDisconnected(DisconnectCause cause)
    {
       
       
    }
}




