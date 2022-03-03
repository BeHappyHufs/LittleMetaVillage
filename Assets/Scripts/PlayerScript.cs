using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;
using MySql.Data.MySqlClient;
using System;


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

    public Image c_body;
    public Image c_face;
    public Image c_hair;
    public Image c_kit;
    public Sprite[] body;
    public Sprite[] face;
    public Sprite[] hair;
    public Sprite[] kit;

    public int num_body;
    public int num_face;
    public int num_hair;
    public int num_kit;


    void Start()
    {
        ReadData();
        ChoiceCharacter();
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
    public void ChoiceCharacter()
    {
        c_body.sprite = body[num_body];
        c_face.sprite = face[num_face];
        c_hair.sprite = hair[num_hair];
        c_kit.sprite = kit[num_kit];

    }

    void ReadData()
    {

        using (MySqlConnection connection = new MySqlConnection("Server=us-cdbr-east-04.cleardb.com;Port=3306;Database=heroku_9739fee54be3ce9;Uid=b30ac1742c1d56;Pwd=6db3d0ba"))
        {
            try
            {
                connection.Open();
                //string temp = "SELECT * FROM avatar WHERE id='";
                string temp = "SELECT * FROM heroku_9739fee54be3ce9.avatar where id='";
                string sql = temp + NickNameText.text + "'";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader table = cmd.ExecuteReader();
                Debug.Log(sql);

                while (table.Read())
                {

                    num_face = (int)table["face"];
                    num_body = (int)table["body"];
                    num_hair = (int)table["hair"];
                    num_kit = (int)table["kit"];



                }
                table.Close();
            }
            catch (Exception ex)
            {

                Debug.Log("잘못된 정보입니다.");

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
