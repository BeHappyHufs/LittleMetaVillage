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

    //public NetworkManager nm;
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

    public static int callRoom = 0;

    public GameObject player;

    // 애니메이션
    Animator anim;

    // 씬 전환시 소리추가
    AudioSource audioSource;
    public AudioClip sound;

    void Start()
    {
        ReadData();
        ChoiceCharacter();
    }

    void Awake()
    {
        // 애니메이션
        anim = GetComponent<Animator>();

        // 닉네임
        //NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        NickNameText.color = PV.IsMine ? Color.green : Color.red;
        this.audioSource = GetComponent<AudioSource>();

        if (PV.IsMine)
        {
            // 2D 카메라
            var CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = transform;
            CM.LookAt = transform;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hospital")
        {
            callRoom = 1;
            PhotonNetwork.LeaveRoom();
            Debug.Log("병원으로 들어감");
            SceneManager.LoadScene("Hospital");
            audioSource.clip = sound;
            player = GameObject.FindWithTag("Player");
            DontDestroyOnLoad(player);
        }
        else if (other.gameObject.tag == "House")
        {
            callRoom = 2;
            PhotonNetwork.LeaveRoom();
            Debug.Log("집으로 들어감");
            SceneManager.LoadScene("House");
            audioSource.clip = sound;
            player = GameObject.FindWithTag("Player");
            DontDestroyOnLoad(player);
        }
        else if (other.gameObject.tag == "Room")
        {
            callRoom = 3;
            PhotonNetwork.LeaveRoom();
            Debug.Log("방으로 들어감");
            SceneManager.LoadScene("Room");
            audioSource.clip = sound;
            player = GameObject.FindWithTag("Player");
            DontDestroyOnLoad(player);
        }
        else if (other.gameObject.tag == "Door")
        {
            callRoom = 0;
            PhotonNetwork.LeaveRoom();
            Debug.Log("메인 화면으로 돌아옴");
            SceneManager.LoadScene("Main");
            audioSource.clip = sound;
            player = GameObject.FindWithTag("Player");
            DontDestroyOnLoad(player);
        }
    }
 
      

    /*    private void OnTriggerEnter2D(Collider other)
        {
            if (other.gameObject.name == "Hospital")
            {
                callRoom = 1;
                PhotonNetwork.LeaveRoom();
                Debug.Log("병원으로 들어감");
            }
            else if(other.gameObject.name == "House")
            {
                callRoom = 2;
                PhotonNetwork.LeaveRoom();
                Debug.Log("집으로 들어감");
            }
            else if(other.gameObject.name == "Room")
            {
                callRoom = 3;
                PhotonNetwork.LeaveRoom();
                Debug.Log("방으로 들어감");
            }
            else
            {
                callRoom = 0;
                PhotonNetwork.LeaveRoom();
                Debug.Log("메인 화면으로 돌아옴");
            }
        }*/



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
                print("Left");
                anim.SetBool("isWalkingLeft", true);
            }

        if(RightMove)
            {
                moveVelocity = new Vector3(+0.10f,0,0);
                transform.position += moveVelocity*moveSpeed*Time.deltaTime;
                print("Right");
                anim.SetBool("isWalkingRight", true);
            }

        if(UPMove)
            {
                moveVelocity = new Vector3(0,+0.10f,0);
                transform.position += moveVelocity*moveSpeed*Time.deltaTime;
                print("Up");
                anim.SetBool("isWalkingUp", true);
            }
        
        if(DownMove)
            {
                moveVelocity = new Vector3(0,-0.10f,0);
                transform.position += moveVelocity*moveSpeed*Time.deltaTime;
                print("Down");
                anim.SetBool("isWalkingDown", true);
            }

        if (!RightMove && !LeftMove && !UPMove && !DownMove)
            {
                print("Stop");
                anim.SetBool("isWalkingLeft", false);
                anim.SetBool("isWalkingRight", false);
                anim.SetBool("isWalkingUp", false);
                anim.SetBool("isWalkingDown", false);
            }

        }
      
    }

     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
      
    }

}
