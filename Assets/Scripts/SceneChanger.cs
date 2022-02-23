using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject player;
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("Demo");
    }

    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("SecondScene");
        player = GameObject.FindWithTag("Player");
        DontDestroyOnLoad(player);

    }



}
