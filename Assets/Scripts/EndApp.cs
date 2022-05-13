using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EndApp : MonoBehaviour
{
    int outGame = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void endapp()
    {
        PhotonNetwork.Disconnect();
        Debug.Log("게임 나갑니다.");
        Application.Quit();
    }

}
