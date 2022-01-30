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

    public InputField id;
    public InputField password;
    public InputField face;
    public InputField hair;
    public InputField body;
    public InputField kit;
    public GameObject upBut;
    public GameObject failState;


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

    public void chageSecne()
    {
        SceneManager.LoadScene("Demo");
    }

    public void up()
    {
        using (MySqlConnection connection = new MySqlConnection("Server=us-cdbr-east-04.cleardb.com;Port=3306;Database=heroku_9739fee54be3ce9;Uid=b30ac1742c1d56;Pwd=6db3d0ba"))
        {
            upBut.SetActive(false);
            failState.SetActive(false);
            string insertQ = "INSERT INTO avatar(id,body,face,hair,kit,password) VALUES('" + id.text + "', " + body.text + ", " + face.text + ", " + hair.text + ", " + kit.text + ", " + password.text + ")";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQ, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    upBut.SetActive(true);
                    failState.SetActive(false);
                    Debug.Log("가입 성공");
                    Debug.Log(insertQ);
                }
                else
                {
                    failState.SetActive(true);
                    upBut.SetActive(false);
                    Debug.Log("가입 실패");
                }

            }
            catch (Exception ex)
            {
                Debug.Log("완전 실패");
                Debug.Log(insertQ);
                Debug.Log(ex.ToString());
            }
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
