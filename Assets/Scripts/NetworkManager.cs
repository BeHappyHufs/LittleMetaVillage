using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    //메인에서 나가기 버튼
    public GameObject EscCanvas;

    //게임 player Object
    public GameObject player;

    //ButtonEvent클래스 타입의 Player 재생성
    public ButtonEvent buttonEvent;

    //ChatTest클래스 타입의 채팅 재생성 : 채팅이 두번 만들어지는 문제 발생;;;
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


    //메인에서 나가기 버튼
    public void EscButton()
    {
        EscCanvas.SetActive(true);
        ButtonManager.SetActive(false);
        ButtonCanvas.SetActive(false);

        ChatEventSystem.SetActive(false);
        ChatCanvas.SetActive(false);
        ChatController.SetActive(false);

        player = GameObject.FindWithTag("Player");
        player.SetActive(false);

    }


    //다시 한번 나가기 버튼 클릭시 수행
    public void DisConnect_Bum()
    {
        DisconnectPanel.SetActive(true);
        EscCanvas.SetActive(false);

        PhotonNetwork.Disconnect();

    }

    public void DisConnect_Bum2()
    {
        DisconnectPanel.SetActive(true);
        SceneManager.LoadScene("Demo");
        EscCanvas.SetActive(false);

        PhotonNetwork.Disconnect();

    }


    //서버가 연결이 안되었을때 실행되는 함수
    public override void OnDisconnected(DisconnectCause cause)
    {
       
       
    }
}




