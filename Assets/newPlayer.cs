using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.SceneManagement;

public class newPlayer : MonoBehaviour
{
    public InputField id;
    public InputField password;
    public InputField face;
    public InputField hair;
    public InputField body;
    public InputField kit;
    public GameObject upBut;
    public GameObject failState;

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
            upBut.SetActive(false);
            failState.SetActive(false);
            string insertQ = "INSERT INTO avatar(id,body,face,hair,kit,password) VALUES('" + id.text + "', " + body.text + ", " + face.text + ", " + hair.text + ", " + kit.text + ", "+password.text + ")";
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

    }
}
