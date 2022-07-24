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

    public GameObject speakObject;

    public Text NickNameText;


    void Awake()
    {
        Screen.SetResolution(960, 540, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }
    //public void Connect() => PhotonNetwork.ConnectUsingSettings();
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        //Destroy(speakObject);
        Debug.Log("-----------------");
        Debug.Log(NickNameText.text);
        foreach (Player player in PhotonNetwork.PlayerListOthers)
        {
            Debug.Log(NickNameText.text);
            Debug.Log(player.NickName);
            if (player.NickName == NickNameText.text)
            {
                SceneManager.LoadScene("SamePlayer");
                //PhotonNetwork.Disconnect();
                Destroy(speakObject);

                Debug.Log("이전에 플레이어가 위치하고 있습니다.");
            }
            Debug.Log("아래는 다른 유저 이름");
            Debug.Log(player.NickName);
        }
        Debug.Log("+++++++++++++++++");
        SceneManager.LoadScene("Main");
    }


    public override void OnConnectedToMaster()
    {
        ///PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
        if (PlayerScript.callRoom == 1)
        {
            
            PhotonNetwork.LocalPlayer.NickName = signup.userName;
            NickNameInput.text = signup.userName;
            PhotonNetwork.JoinOrCreateRoom("Hospital", new RoomOptions { MaxPlayers = 6 }, null);
            Debug.Log("병원 서버 입장 완료");
        }
        else if(PlayerScript.callRoom == 2)
        {
            PhotonNetwork.LocalPlayer.NickName = signup.userName;
            NickNameInput.text = signup.userName;
            PhotonNetwork.JoinOrCreateRoom("House", new RoomOptions { MaxPlayers = 6 }, null);
            Debug.Log("집 서버 입장 완료");
        }
        else if(PlayerScript.callRoom == 3)
        {
            PhotonNetwork.LocalPlayer.NickName = signup.userName;
            NickNameInput.text = signup.userName;
            PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
            Debug.Log("방 서버 입장 완료");
        }
        else
        {
            PhotonNetwork.LocalPlayer.NickName = signup.userName;
            NickNameInput.text = signup.userName;
            PhotonNetwork.JoinOrCreateRoom("Lungnaha", new RoomOptions { MaxPlayers = 6 }, null);
            Debug.Log("메인 화면 입장 완료");
            Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        }
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
        chatTest.ChatStart();
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
        DisconnectPanel.SetActive(true);
        EscCanvas.SetActive(false);

        PhotonNetwork.Disconnect();
        Application.Quit();


    }


    //다시 한번 나가기 버튼 클릭시 수행
    public void DisConnect_Bum()
    {
        //player = GameObject.FindWithTag("Player");
        //player.SetActive(false);
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




