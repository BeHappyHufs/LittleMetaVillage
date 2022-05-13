using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.SceneManagement;
public class checkMember : MonoBehaviourPunCallbacks
{
    public Text NickNameText;
    public PhotonView PV;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        /*int check = 0;
        Debug.Log("여기 등장!!");
        
        foreach (Player player in PhotonNetwork.PlayerListOthers)
        {
            Debug.Log(player.NickName);
            if (player.NickName == NickNameText.text)
            {
                Debug.Log("ERROR");
            }
            check++;
        }*/
    }
    void Awake()

    {
        // 닉네임
        /*NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;*/




    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            int check = 0;
            Debug.Log("여기 등장!!");
            if (PV.IsMine)
            {
                Debug.Log("-----------------");
                Debug.Log(NickNameText.text);
                foreach (Player player in PhotonNetwork.PlayerListOthers)
                {
                    Debug.Log(NickNameText.text);
                    Debug.Log(player.NickName);
                    if (player.NickName == NickNameText.text)
                    {
                        PhotonNetwork.Disconnect();
                        Debug.Log("이전에 플레이어가 위치하고 있습니다.");
                        SceneManager.LoadScene("SamePlayer");
                    }
                    check++;
                    Debug.Log("아래는 다른 유저 이름");
                    Debug.Log(player.NickName);
                }
                Debug.Log("+++++++++++++++++");
            }
            count++;
        }

    }
}