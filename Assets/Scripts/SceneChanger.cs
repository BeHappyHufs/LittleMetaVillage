using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneChanger : MonoBehaviour
{
    public static string myName = "";
    public static int callRoom = 0;
    public GameObject player;
    public GameObject speakObject;
    public void ChangeFirstScene()
    {
        Destroy(speakObject);
        Debug.Log("보이스 파괴 완료, 씬 전환 시작합니다.");
        SceneManager.LoadScene("Demo");
        
    }

    public void ChangeSecondScene()
    {
        callRoom = 1;
        myName = PhotonNetwork.LocalPlayer.NickName;
        PhotonNetwork.LeaveRoom();
        Debug.Log("방 나가기");
        SceneManager.LoadScene("SecondScene");
        //Destroy(speakObject);
        player = GameObject.FindWithTag("Player");
        DontDestroyOnLoad(player);
        

    }



}
