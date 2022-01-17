using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;


public class PlayerScript :  MonoBehaviourPunCallbacks, IPunObservable
{
    // Start is called before the first frame update
    public bool LeftMove = false;
    
    public bool RightMove = false;

    public bool UPMove = false;

    public bool DownMove = false;

    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 20;

    public Text NickNameText;

    public PhotonView PV;


    void Start()
    {
       
    }

    void Awake()
    {
        // 닉네임
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        NickNameText.color = PV.IsMine ? Color.green : Color.red;

        if (PV.IsMine)
        {
            // 2D 카메라
            var CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = transform;
            CM.LookAt = transform;
        } 

    }

    // Update is called once per frame
    void Update()
    {
        if(PV.IsMine){
             if(LeftMove)
            {
                moveVelocity = new Vector3(-0.10f,0,0);
                transform.position += moveVelocity*moveSpeed*Time.deltaTime;
            }

        if(RightMove)
            {
                moveVelocity = new Vector3(+0.10f,0,0);
                transform.position += moveVelocity*moveSpeed*Time.deltaTime;

            }

        if(UPMove)
            {
                moveVelocity = new Vector3(0,+0.10f,0);
                transform.position += moveVelocity*moveSpeed*Time.deltaTime;

            }
        
        if(DownMove)
            {
                moveVelocity = new Vector3(0,-0.10f,0);
                transform.position += moveVelocity*moveSpeed*Time.deltaTime;

            }
       
        }

      
    }

     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
      
    }



}
