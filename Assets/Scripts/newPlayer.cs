using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class newPlayer : MonoBehaviour
{
    public InputField id;
    public InputField password;
    //public InputField face;
    //public InputField hair;
    //public InputField body;
    //public InputField kit;
    public GameObject upBut;
    public GameObject failState;
    public GameObject connectButton;
    public GameObject preButton;

    public GameObject signUp1;
    public GameObject signUp2;
    public GameObject signUp3;
    public GameObject signUp4;
    public GameObject signUp5;
    public GameObject doubleCheck;

    public String hair = "0";
    public String face = "0";
    public String body = "0";
    public String kit = "0";

    public void preButton1()
    {
        signUp1.SetActive(false);
        //PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Demo");
    }

    public void nextButton1()
    {
        signUp1.SetActive(false);
        signUp2.SetActive(true);
    }

    public void nextButton2()
    {
        signUp2.SetActive(false);
        signUp3.SetActive(true);

    }
    public void preButton2()
    {
        signUp2.SetActive(false);
        signUp1.SetActive(true);

    }

    public void nextButton3()
    {
        signUp3.SetActive(false);
        signUp4.SetActive(true);

    }

    public void preButton3()
    {
        signUp3.SetActive(false);
        signUp2.SetActive(true);

    }

    public void nextButton4()
    {
        signUp4.SetActive(false);
        signUp5.SetActive(true);

    }

    public void preButton4()
    {
        signUp4.SetActive(false);
        signUp3.SetActive(true);

    }

    public void preButton5()
    {
        signUp5.SetActive(false);
        signUp4.SetActive(true);

    }

    public void hairButton1()
    {
        hair = "0";
    }

    public void hairButton2()
    {
        hair = "1";
    }

    public void hairButton3()
    {
        hair = "2";
    }

    public void hairButton4()
    {
        hair = "3";
    }

    public void faceButton1()
    {
        face = "0";
    }

    public void faceButton2()
    {
        face = "1";
    }

    public void faceButton3()
    {
        face = "2";
    }

    public void bodyButton1()
    {
        body = "0";
    }

    public void bodyButton2()
    {
        body = "1";
    }

    public void bodyButton3()
    {
        body = "2";
    }

    public void kitButton1()
    {
        kit = "0";
    }

    public void kitButton2()
    {
        kit = "1";
    }

    public void kitButton3()
    {
        kit = "2";
    }

    public void kitButton4()
    {
        kit = "3";
    }

    public void okButton()
    {
        Debug.Log("enter");
        doubleCheck.SetActive(false);
        signUp5.SetActive(true);
    }



    // Start is called before the first frame update
    void Start()
    {

    }
    public void chageSecne()
    {
        SceneManager.LoadScene("Demo");
    }

    public void up()
    {
        using (MySqlConnection connection = new MySqlConnection("Server=us-cdbr-east-04.cleardb.com;Port=3306;Database=heroku_9739fee54be3ce9;Uid=b30ac1742c1d56;Pwd=6db3d0ba"))
        {
            //upBut.SetActive(false);
            failState.SetActive(false);
            string insertQ = "INSERT INTO avatar(id,body,face,hair,kit,password) VALUES('" + id.text + "', " + body + ", " + face + ", " + hair + ", " + kit + ", "+password.text + ")";
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
                    SceneManager.LoadScene("Demo");
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
                doubleCheck.SetActive(true);
                signUp5.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
